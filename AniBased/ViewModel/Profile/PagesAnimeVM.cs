﻿using AniBased.Model;
using AniBased.View.Home;
using AniBased.ViewModel.Base;
using AniBased.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.ViewModel.Profile
{
     class PagesAnimeVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        private ObservableCollection<PosterRow> _posters = new ObservableCollection<PosterRow>();
        public ObservableCollection<PosterRow> Posters { get => _posters; set => Set(ref _posters, value); }

        private WindowAnimesVM _windowFavorites;
        public WindowAnimesVM WindowFavorites { get => _windowFavorites; set => Set(ref _windowFavorites, value); }

        private WindowAnimesVM _windowViewed;
        public WindowAnimesVM WindowViewed { get => _windowViewed; set => Set(ref _windowViewed, value); }

        private WindowAnimesVM _windowHistory;
        public WindowAnimesVM WindowHistory { get => _windowHistory; set => Set(ref _windowHistory, value); }

        private WindowAnimesVM _windowPlanned;
        public WindowAnimesVM WindowPlanned { get => _windowPlanned; set => Set(ref _windowPlanned, value); }

        private WindowAnimesVM _windowWatching;
        public WindowAnimesVM WindowWatching { get => _windowWatching; set => Set(ref _windowWatching, value); }

        #endregion

        #region КОМАНДЫ
        #endregion

        #region МЕТОДЫ
        public async Task InitializeComponent()
        {
            await RunInitialize();
        }

        private async Task RunInitialize()
        {
            if (_mainVM.User.Library.Anime.Count > 0)
            {
                foreach (var item in _mainVM.User.Library.Anime[0].Animes)
                {
                    _posters.Add(new PosterRow(new PosterVM(item)));
                }
                WindowFavorites.Posters = _posters;
            }
        }
        #endregion

        public PagesAnimeVM(MainVM mainVM)
        {
            _mainVM = mainVM;
            WindowFavorites = new WindowAnimesVM(_mainVM);
            WindowViewed = new WindowAnimesVM(_mainVM);
            WindowHistory = new WindowAnimesVM(_mainVM);
            WindowPlanned = new WindowAnimesVM(_mainVM);
            WindowWatching = new WindowAnimesVM(_mainVM);
        }
    }
}
