using AniBased.ViewModel.Base;
using AniBased.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AniBased.ViewModel.Profile
{
    internal class MainProfileVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        private double _widthWindow;
        public double WidthWindow { get => _widthWindow; set => Set(ref _widthWindow, value); }

        private double _heightWindow;
        public double HeightWindow { get => _heightWindow; set => Set(ref _heightWindow, value); }

        private NavigationCommandVM _navigationCommandVM;
        public NavigationCommandVM NavigationCommandVM { get => _navigationCommandVM; set => Set(ref _navigationCommandVM, value); }

        private PagesAnimeVM _pagesAnimeVM;
        public PagesAnimeVM PagesAnimeVM { get => _pagesAnimeVM; set => Set(ref _pagesAnimeVM, value); }

        private UserProfileVM _userProfile;
        public UserProfileVM UserProfileVM { get => _userProfile; set => Set(ref _userProfile, value); }


        #endregion

        #region КОМАНДЫ
        #endregion

        #region МЕТОДЫ
        public void MakeFullScreen()
        {
            double screenWidth = SystemParameters.WorkArea.Width;
            double screenHeight = SystemParameters.WorkArea.Height;
            HeightWindow = screenHeight;
            WidthWindow = screenWidth;
        }
        #endregion

        public MainProfileVM(MainVM mainVM)
        {
            _mainVM = mainVM;
            _navigationCommandVM = _mainVM.NavigationCommandVM;
            _pagesAnimeVM = _mainVM.PagesAnimeVM;
            _userProfile = _mainVM.UserProfileVM;
        }
    }
}