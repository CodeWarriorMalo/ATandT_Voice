using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TestPhone8.Resources;
using System.Windows.Media;

namespace TestPhone8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Test2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string c = Test2.Text.Replace(".","").ToUpper();
            switch(c)
            {
                case "RED": Test2.Background = new SolidColorBrush(Colors.Red); break;
                case "BLUE": Test2.Background = new SolidColorBrush(Colors.Blue); break;
                case "GREEN": Test2.Background = new SolidColorBrush(Colors.Green); break;
                case "YELLOW": Test2.Background = new SolidColorBrush(Colors.Yellow); break;
                case "ORANGE": Test2.Background = new SolidColorBrush(Colors.Orange); break;
                default: Test2.Background = new SolidColorBrush(Colors.White); break;
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}