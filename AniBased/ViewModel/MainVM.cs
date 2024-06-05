using AniBased.ViewModel.Base;
using AniBased.ViewModel.Home;
using AniBased.ViewModel.Profile;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Media3D;

namespace AniBased.ViewModel
{
    internal class MainVM : BaseVM
    {

        #region СВОЙСТВА VM

        private double _x;
        public double X { get => _x; set => Set(ref _x, value); }

        private double _y;
        public double Y { get => _y; set => Set(ref _y, value); }


        private BaseVM _startVM;
        public BaseVM StartVM { get => _startVM; set => Set(ref _startVM, value); }

        private EntryVM _entryVM;
        public EntryVM EntryVM { get => _entryVM; set => Set(ref _entryVM, value); }

        private RegistryVM _registryVM;
        public RegistryVM RegistryVM { get => _registryVM; set => Set(ref _registryVM, value); }

        private ToolBarVM _toolBarVM;
        public ToolBarVM ToolBarVM { get => _toolBarVM; set => Set(ref _toolBarVM, value); }

        private HomeVM _homeVM;
        public HomeVM HomeVM { get => _homeVM; set => Set(ref _homeVM, value); }

        private SearchStringVM _searchStringVM;
        public SearchStringVM SearchStringVM { get => _searchStringVM; set => Set(ref _searchStringVM, value); }

        private WindowAnimesVM _windowAnimesVM;
        public WindowAnimesVM WindowAnimesVM { get => _windowAnimesVM; set => Set(ref _windowAnimesVM, value); }

        private NavigationCommandVM _navigationCommandVM;
        public NavigationCommandVM NavigationCommandVM { get => _navigationCommandVM; set => Set(ref _navigationCommandVM, value); }

        private NewsBlockVM _newsBlockVM;
        public NewsBlockVM NewsBlockVM { get => _newsBlockVM; set => Set(ref _newsBlockVM, value); }

        private PagesAnimeVM _pagesAnimeVM;
        public PagesAnimeVM PagesAnimeVM { get => _pagesAnimeVM; set => Set(ref _pagesAnimeVM, value); }

        private UserProfileVM _userProfile;
        public UserProfileVM UserProfileVM { get => _userProfile; set => Set(ref _userProfile, value); }
        
        private MainProfileVM _mainProfileVM;
        public MainProfileVM MainProfileVM { get => _mainProfileVM; set => Set(ref _mainProfileVM, value); }

        #endregion

        public void SetStartLocation()
        {
            X = 0;
            Y = 0;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        public MainVM() 
        {
            _startVM = new EntryVM(this);
            _entryVM = (EntryVM)_startVM;
            _registryVM = new RegistryVM(this);
            _toolBarVM = new ToolBarVM(this);
            _navigationCommandVM = new NavigationCommandVM(this);
            _searchStringVM = new SearchStringVM(this);
            _windowAnimesVM = new WindowAnimesVM(this);
            _newsBlockVM = new NewsBlockVM(this);
            _homeVM = new HomeVM(this);
            _pagesAnimeVM = new PagesAnimeVM(this);
            _userProfile = new UserProfileVM(this);
            _mainProfileVM = new MainProfileVM(this);
        } 
    }
}
