using AniBased.Infastructure.Command;
using AniBased.ViewModel.Base;
using AniBased.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AniBased.ViewModel
{
    class HomeVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        private SearchStringVM _searchStringVM;
        public SearchStringVM SearchStringVM { get => _searchStringVM; set => Set(ref _searchStringVM, value); }

        private WindowAnimesVM _windowAnimesVM;
        public WindowAnimesVM WindowAnimesVM { get => _windowAnimesVM; set => Set(ref _windowAnimesVM, value); }

        private NewsBlockVM _newsBlockVM;
        public NewsBlockVM NewsBlockVM { get => _newsBlockVM; set => Set(ref _newsBlockVM, value); }

        private NavigationCommandVM _navigationCommandVM;
        public NavigationCommandVM NavigationCommandVM { get => _navigationCommandVM; set => Set(ref _navigationCommandVM, value); }

        #endregion

        #region КОМАНДЫ

        #endregion

        #region МЕТОДЫ

        #endregion

        public HomeVM(MainVM mainVM)
        {
            _mainVM = mainVM;
            _searchStringVM = _mainVM.SearchStringVM;
            _windowAnimesVM = _mainVM.WindowAnimesVM;
            _newsBlockVM = _mainVM.NewsBlockVM;
            _navigationCommandVM = _mainVM.NavigationCommandVM;
        }
    }
}