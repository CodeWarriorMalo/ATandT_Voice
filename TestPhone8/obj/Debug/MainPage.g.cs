﻿#pragma checksum "C:\Projects\ATandT_Voice\TestPhone8\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5FD6F69FD2344BC00D8DFFC7DDDA2D00"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using VoiceATTPhone8;


namespace TestPhone8 {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal VoiceATTPhone8.VoiceTextBox Test1;
        
        internal VoiceATTPhone8.VoiceTextBox Test2;
        
        internal VoiceATTPhone8.VoiceTextBox Test3;
        
        internal VoiceATTPhone8.VoiceRecordButton btnVoiceRecord;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/TestPhone8;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.Test1 = ((VoiceATTPhone8.VoiceTextBox)(this.FindName("Test1")));
            this.Test2 = ((VoiceATTPhone8.VoiceTextBox)(this.FindName("Test2")));
            this.Test3 = ((VoiceATTPhone8.VoiceTextBox)(this.FindName("Test3")));
            this.btnVoiceRecord = ((VoiceATTPhone8.VoiceRecordButton)(this.FindName("btnVoiceRecord")));
        }
    }
}
