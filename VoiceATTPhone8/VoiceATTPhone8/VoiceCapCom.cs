using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VoiceATTPhone8
{
    public class VoiceCapCom
    {
        private Dictionary<Control, string> _VoiceActivatedControls = new Dictionary<Control, string>();
        private Control _ActiveControl;
        public static VoiceCapCom Instance = new VoiceCapCom();

        public void VoiceCommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (_VoiceActivatedControls.ContainsKey(target as Control) == false)
            {
                _VoiceActivatedControls.Add(target as Control, e.NewValue as string);
            }
            else
            {
                _VoiceActivatedControls[target as Control] = e.NewValue as string;
            }
        }

        /// <summary>
        /// Activates the control, if it exists, based on the words spoken
        /// </summary>
        /// <param name="command"></param>
        /// <returns>true if control is found in dictionary, false otherwise</returns>
        public bool ActivateControl(string command)
        {
            if (_VoiceActivatedControls.Any(p => p.Value == command.ToUpper()))
            {
                var item = _VoiceActivatedControls.Where(p => p.Value == command.ToUpper()).First();
                _ActiveControl = item.Key as Control;
                //_ActiveControl.Focus();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sends the text spoken to the active control
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            var ctl = _ActiveControl as VoiceTextBox;
            if (ctl != null)
            {
                if (ctl is TextBox) { ((TextBox)_ActiveControl).Text = text; return; }
            }
            //// Future revisions will include support for ComboBox and CheckBox
            //ctl = _ActiveControl as VoiceComboBox;
            //if (ctl != null)
            //{
            //    if (ctl is ComboBox) { ((ComboBox)_ActiveControl).SelectedValue = text; return; }
            //}
            //ctl = _ActiveControl as VoiceCheckBox;
            //if (ctl != null)
            //{
            //    if (ctl is CheckBox) { ((CheckBox)_ActiveControl).IsChecked = text == "CHECKED"; return; }
            //}
        }
    }
}
