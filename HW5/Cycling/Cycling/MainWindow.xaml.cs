using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cycling.Messaging;
using Cycling.Views;
using GalaSoft.MvvmLight.Messaging;

namespace Cycling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<GenericMessage<string>>(this, MainNavigation.Token, HandleMainNavigationMessage);
            Messenger.Default.Register<GenericMessage<string>>(this, LightboxNavigation.Token, HandleLightboxNavigationMessage);
        }

        private void HandleLightboxNavigationMessage(GenericMessage<string> message)
        {
            switch (message.Content)
            {
                case LightboxNavigation.SELECT_RACE:
                    LightboxContent.Content = new SelectRaceView();
                    LightboxContent.Visibility = Visibility.Visible;
                    break;
                case LightboxNavigation.CLOSE_Lightbox:
                    LightboxContent.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void HandleMainNavigationMessage(GenericMessage<string> message)
        {
            switch (message.Content)
            {
                case MainNavigation.MAIN_MENU:
                    MainContent.Content = null;
                    MainMenu.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
