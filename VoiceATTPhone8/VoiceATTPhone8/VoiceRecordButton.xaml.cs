using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ATT.WP8.Controls.Utils;
using ATT.WP8.SDK;
using ATT.WP8.SDK.Entities;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace VoiceATTPhone8
{
    public partial class VoiceRecordButton : Button
    {
        private enum RecordState
        {
            Idle,
            Recording,
            Converting
        }

        private SoundRecorder _soundRecorder;
        private RecordState _currentState;
        private string clientId, clientSecret, uriString;


        public VoiceRecordButton()
        {
            InitializeComponent();
            _currentState = RecordState.Idle;
            SetState(_currentState);
            CreateSoundRecorder();
            SetupProgressBars();

            Unloaded += (sender, args) => _soundRecorder.Dispose();
        }

        private async void SetupProgressBars()
        {
            StatusProgress_LTR.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            StatusProgress_LTR.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            StatusProgress_RTL.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            StatusProgress_RTL.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            await Task.Yield();
        }

        private void CreateSoundRecorder()
        {
            try
            {
                _soundRecorder = new SoundRecorder();
                _soundRecorder.RecodingTimerStoped += RecodingTimerStoped;
            }
            catch (MicrophoneNotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RecodingTimerStoped(object sender, EventArgs eventArgs)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => LayoutRoot_Tap(this, new GestureEventArgs()));
        }

        private async void LayoutRoot_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            StatusProgress_LTR.Margin = new Thickness(10, 5, 0, 0);
            StatusProgress_LTR.Width = this.Width - 20;
            StatusProgress_RTL.Margin = new Thickness(10, this.Height - 14, 0, 0);
            StatusProgress_RTL.Width = this.Width - 20;
            await Task.Yield();
        }

        private async void LayoutRoot_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                if (_currentState == RecordState.Converting)
                {
                    return;
                }

                switch (_currentState)
                {
                    case RecordState.Idle:
                        SetState(RecordState.Recording);
                        _soundRecorder.StartRecording();
                        break;
                    case RecordState.Recording:
                        _currentState = RecordState.Converting;
                        SetState(RecordState.Converting);
                        this.IsEnabled = false;
                        _soundRecorder.StopRecording();

                        clientId = "qlkztshqrtexp6pt0tdmcqwjwhmsykpq";
                        clientSecret = "i4hefoukrzpzthosouh42iojwnvakah3";
                        uriString = "https://api.att.com";
                        try
                        {
                            ContentInfo speechContentInfo = new ContentInfo();
                            speechContentInfo.Content = await _soundRecorder.GetBytes();
                            speechContentInfo.Name = _soundRecorder.FilePath;

                            SpeechService speechService = new SpeechService(new ATT.WP8.SDK.Entities.AttServiceSettings(clientId, clientSecret, new Uri(uriString)));
                            SpeechResponse speechResponse = await speechService.SpeechToText(speechContentInfo);
                            if (null != speechResponse)
                            {
                                Console.WriteLine(speechResponse.GetTranscription());

                                if (speechResponse.Recognition.NBest != null &&
                                    speechResponse.Recognition.NBest[0].Confidence > 0.1M)
                                {
                                    string textToSet = string.Empty;
                                    string fieldName = speechResponse.Recognition.NBest[0].Words[0];
                                    bool found = VoiceATTPhone8.VoiceCapCom.Instance.ActivateControl(fieldName);
                                    if (found)
                                    {
                                        textToSet = speechResponse.GetTranscription().Remove(0, fieldName.Length + 1);
                                    }
                                    else
                                    {
                                        if (speechResponse.GetTranscription().StartsWith("Set Field", StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            fieldName = speechResponse.Recognition.NBest[0].Words[2];
                                            found = VoiceATTPhone8.VoiceCapCom.Instance.ActivateControl(fieldName);
                                            if (!found)
                                            {
                                                throw new ArgumentException("Command not recognized");
                                            }
                                        }
                                        textToSet = speechResponse.GetTranscription().Remove(0, fieldName.Length + 11);
                                    }
                                    VoiceATTPhone8.VoiceCapCom.Instance.SetText(textToSet);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        SetState(RecordState.Idle);
                        this.IsEnabled = true;
                        break;
                    case RecordState.Converting:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            await Task.Yield();
        }

        private RecordState _State;
        private async void SetState(RecordState state)
        {
            _State = state;
            FrameworkDispatcher.Update();
            Dispatcher.BeginInvoke(new Action(SetStateAction));
        }
        private void SetStateAction()
        {
            try
            {
                _currentState = _State;
                string caption = string.Empty;
                Visibility visibility = Visibility.Visible;
                switch (_State)
                {
                    case RecordState.Idle:
                        caption = "Start";
                        visibility = System.Windows.Visibility.Collapsed;
                        break;
                    case RecordState.Recording:
                        caption = "Stop";
                        visibility = System.Windows.Visibility.Visible;
                        break;
                    case RecordState.Converting:
                        caption = "Converting";
                        visibility = System.Windows.Visibility.Visible;
                        break;
                }
                base.Content = caption;
                StatusProgress_LTR.Visibility = visibility;
                StatusProgress_RTL.Visibility = visibility;
                //StatusProgress_LTR.Visibility = Visibility.Visible;
                //StatusProgress_RTL.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            LayoutRoot_Tap(sender, e);
        }
    }
}
