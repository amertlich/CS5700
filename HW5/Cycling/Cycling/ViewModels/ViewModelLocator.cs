using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Ninject;

namespace Cycling.ViewModels
{
    public class ViewModelLocator
    {
        private static readonly IList<ICleanup> _trash = new List<ICleanup>();
        private static MainMenuViewModel _mainMenu;
        private SelectRaceViewModel _selectRace;
        // private readonly StandardKernel _kernel;

        public ViewModelLocator()
        {
            
        }

        public MainMenuViewModel MainMenu
        {
            get
            {
                if (_mainMenu != null)
                {
                    _mainMenu.Cleanup();
                    _trash.Remove(_mainMenu);
                }

                _mainMenu = new MainMenuViewModel();
                _trash.Add(_mainMenu);

                return _mainMenu;
            }
        }

        public SelectRaceViewModel SelectRace
        {
            get
            {
                if (_selectRace != null)
                {
                    _selectRace.Cleanup();
                    _trash.Remove(_selectRace);
                }

                _selectRace = new SelectRaceViewModel();
                _trash.Add(_selectRace);

                return _selectRace;
            }
        }



        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            foreach (var item in _trash)
            {
                if (item == null)
                {
                    continue;
                }

                item.Cleanup();
            }

            _trash.Clear();
        }
    }
}
