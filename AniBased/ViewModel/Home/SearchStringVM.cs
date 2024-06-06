using AniBased.Infastructure.Command;
using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AniBased.ViewModel.Home
{
    class SearchStringVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        private string _searchMessage;
        public string SearchMessage
        {
            get => _searchMessage;
            set
            {
                if (_searchMessage != value)
                {
                    Set(ref _searchMessage, value);
                    OnMessageChanged();
                }
            }
        }
        #endregion

        #region КОМАНДЫ
        #region Сортировать

        public ICommand SortCommand
        {
            get => new AsyncRelayCommand(OnSortCommand, CanSortCommand);
        }

        private async Task OnSortCommand()
        {
            _mainVM.StartVM = _mainVM.HomeVM;
        }

        private bool CanSortCommand()
        {
            return true;
        }

        #endregion
        #endregion

        #region МЕТОДЫ

        private async void OnMessageChanged()
        {
            await _mainVM.WindowAnimesVM.SearchPosters(_searchMessage);
        }

        #endregion

        public SearchStringVM(MainVM mainVM)
        {
            _mainVM = mainVM;
        }
    }
}