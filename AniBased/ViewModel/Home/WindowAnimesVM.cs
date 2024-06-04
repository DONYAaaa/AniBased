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

        public ICommand Entry
        {
            get => new RelayCommand((_) => OnEntry(),
                                    (_) => CanEntry());
        }

        private void OnEntry()
        {
            
        }

        private bool CanEntry()
        {
            return true;
        }

        #endregion

        #region МЕТОДЫ

        #endregion

        public WindowAnimesVM(MainVM mainVM)
        {
            _mainVM = mainVM;

            for (int i = 0; i < 10; i++)
            {
                PosterVM posterVM = new PosterVM(_mainVM);
                posterVM.NameOfAnime = "1";
                posterVM.YearOfRelease = "2";
                posterVM.Genres = "3";
                posterVM.Country = "4";
                posterVM.Studio = "5";
                Posters.Add(new PosterRow(posterVM));
            }
        }
    }
}