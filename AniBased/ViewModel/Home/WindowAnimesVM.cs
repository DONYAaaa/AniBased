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
        public ObservableCollection<PosterRow> Posters { get => _posters; set { Set(ref _posters, value); } }

        #endregion

        #region КОМАНДЫ

        #endregion

        #region МЕТОДЫ
        public void Refresh()
        {
            OnPropertyChanged(nameof(Posters));
        }

        public async Task SearchPosters(string input)
        {
            if (input.Length > 0)
            {

                var filteredPosters = Posters.Where(p => p.PosterVM.NameOfAnime.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();

                for (int i = Posters.Count - 1; i >= 0; i--)
                {
                    if (!filteredPosters.Contains(Posters[i]))
                    {
                        Posters.RemoveAt(i);
                    }
                }

                foreach (var poster in filteredPosters)
                {
                    if (!Posters.Contains(poster))
                    {
                        Posters.Add(poster);
                    }
                }
            }
            else
            {
                _mainVM.EntryVM.GetAllPosters();
            }
        }


        #endregion

        public WindowAnimesVM(MainVM mainVM)
        {
            _mainVM = mainVM;
        }
    }
}