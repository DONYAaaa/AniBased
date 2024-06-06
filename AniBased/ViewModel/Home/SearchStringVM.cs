using AniBased.Infastructure.Command;
using AniBased.Model.Strategy;
using AniBased.Model.Strategy.Base;
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
            get => new RelayCommand((_) => OnSortCommand(), 
                                    (_) => CanSortCommand());
        }

        private async Task OnSortCommand()
        {
            await _mainVM.NewsBlockVM.SoringForGenre();
        }

        private bool CanSortCommand()
        {
            if (_mainVM.NewsBlockVM.GenresOfFilter.Count>0) return true;
            else return false;
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