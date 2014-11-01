using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using System.Windows.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VoiceATTPhone8
{
    public sealed partial class VoiceTextBox : TextBox
    {
        public static readonly DependencyProperty VoiceCommandProperty = DependencyProperty.RegisterAttached(
        "VoiceCommand",
        typeof(string),
        typeof(Control),
        new PropertyMetadata(string.Empty, new PropertyChangedCallback(VoiceCapCom.Instance.VoiceCommandChanged)));
        public string VoiceCommand
        {
            get { return (string)GetValue(VoiceCommandProperty); }
            set { SetValue(VoiceCommandProperty, value.ToUpper()); }
        }
    
        public VoiceTextBox()
        {
            this.InitializeComponent();
        }
    }
}
