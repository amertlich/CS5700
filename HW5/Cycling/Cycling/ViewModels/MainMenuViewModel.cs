using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cycling.Messaging;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace Cycling.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        private ICommand _viewRaceResultsCommand;
        private ICommand _vieweventsCommand;
        private ICommand _viewCyclistsCommand;
        private ICommand _viewUSACCommand;

        public ICommand ViewRaceResultsCommand
        {
            get
            {
                return _viewRaceResultsCommand ??
                       (_viewRaceResultsCommand = new RelayCommand(ShowSelectRaceLightbox, CanShowSelectRaceLightbox));
            }
        }

        public ICommand ViewEventsCommand
        {
            get
            {
                return _vieweventsCommand ??
                       (_vieweventsCommand = new RelayCommand(ShowEventLightbox, CanShowEventLightbox));
            }
        }

        public ICommand ViewCyclistsCommand
        {
            get
            {
                return _viewCyclistsCommand ??
                       (_viewCyclistsCommand = new RelayCommand(ShowEventLightbox, CanShowEventLightbox));
            }
        }

        public ICommand ViewUsacCommand
        {
            get
            {
                return _viewUSACCommand ??
                       (_viewUSACCommand = new RelayCommand(ShowEventLightbox, CanShowEventLightbox));
            }
        }

        private void ShowSelectRaceLightbox()
        {
            Messenger.Default.Send(new GenericMessage<string>(LightboxNavigation.SELECT_RACE), LightboxNavigation.Token);
        }

        private bool CanShowSelectRaceLightbox()
        {
            return true;
        }

        private bool CanShowEventLightbox()
        {
            return true;
        }

        private void ShowEventLightbox()
        {
            MessageBox.Show("TODO");
        }
    }

    
}
