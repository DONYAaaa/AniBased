using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.ViewModel.Home
{
    class SearchStringVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        private string _searchMessage;
        public string SearchMessage { get => _searchMessage; set => Set(ref _searchMessage, value); }

        #endregion

        #region КОМАНДЫ

        #endregion

        #region МЕТОДЫ

        #endregion

        public SearchStringVM(MainVM mainVM)
        {
            _mainVM = mainVM;
        }
    }
}