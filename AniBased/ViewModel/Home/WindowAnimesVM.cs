using AniBased.Infastructure.Command;
using AniBased.Model;
using AniBased.View.Home;
using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AniBased.ViewModel.Home
{
    class WindowAnimesVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        private ObservableCollection<PosterRow> _posters = new ObservableCollection<PosterRow>();
        public ObservableCollection<PosterRow> Posters { get => _posters; set => Set(ref _posters, value); }

        #endregion

        #region КОМАНДЫ

        #endregion

        #region МЕТОДЫ
        public void Refresh()
        {
            OnPropertyChanged(nameof(Posters));
        }
        #endregion

        public WindowAnimesVM(MainVM mainVM)
        {
            _mainVM = mainVM;
        }
    }
}