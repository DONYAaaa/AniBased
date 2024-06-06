using AniBased.Infastructure.Command;
using AniBased.Model.BLL.Entities;
using AniBased.Model.BLL.Service;
using AniBased.Repository.Interface;
using AniBased.Repository;
using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AniBased.Model.Strategy.Base;
using AniBased.Model.Strategy;
using AniBased.Model;
using System.Collections.ObjectModel;

namespace AniBased.ViewModel.Home
{
     class NewsBlockVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        private List<DateOnly> _yearsOfRealese;
        public List<DateOnly> YearsOfRealese { get => _yearsOfRealese; set => Set(ref _yearsOfRealese, value); }

        private DateOnly _realeseDate;
        public DateOnly RealeseDate { get => _realeseDate; set => Set(ref _realeseDate, value); }

        private bool _isCheckedYear;
        public bool IsCheckedYear { get => _isCheckedYear; set => Set(ref _isCheckedYear, value); }



        private List<string> _studios;
        public List<string> Studios { get => _studios; set => Set(ref _studios, value); }

        private string _studio;
        public string Studio { get => _studio; set => Set(ref _studio, value); }

        private bool _isCheckedStudio;
        public bool IsCheckedStudio { get => _isCheckedStudio; set => Set(ref _isCheckedStudio, value); }


        private List<int> _numbersOfEpisode;
        public List<int> NumbersOfEpisode { get => _numbersOfEpisode; set => Set(ref _numbersOfEpisode, value); }

        private string _countOfEpisode;
        public string CountOfEpisode { get => _countOfEpisode; set => Set(ref _countOfEpisode, value); }

        private bool _isCheckedNumberOfEpisode;
        public bool IsCheckedNumberOfEpisode { get => _isCheckedNumberOfEpisode; set => Set(ref _isCheckedNumberOfEpisode, value); }


        private List<string> _genres;
        public List<string> Genres { get => _genres; set => Set(ref _genres, value); }

        private string _genre;
        public string Genre { get => _genre; set => Set(ref _genre, value); }


        private List<Genre> _genresOfFilter;
        public List<Genre> GenresOfFilter { get => _genresOfFilter; set => Set(ref _genresOfFilter, value); }
        #endregion

        #region КОМАНДЫ

        #region Добавить жанр

        public ICommand AddGenre
        {
            get => new RelayCommand((_)=>OnAddGenre(), 
                                    (_)=>CanAddGenre());
        }

        private void OnAddGenre()
        {
            _genresOfFilter.Add(new Genre(_genre));
        }
        private bool CanAddGenre()
        {
            if (_genre == null) return false;
            else return true;
        }

        #endregion

        #region Очистить жанры

        public ICommand RefreshGenres
        {
            get => new AsyncRelayCommand(OnRefreshGenres, CanRefreshGenres);
        }

        private async Task OnRefreshGenres()
        {
            _genresOfFilter.Clear();
        }
        private bool CanRefreshGenres()
        {
            return true;
        }

        #endregion

        #endregion

        #region МЕТОДЫ

        public async Task GetAllYearOfRealese(List<Anime> animes)
        {
            _yearsOfRealese = new List<DateOnly>();

            foreach (var item in animes)
            {
                _yearsOfRealese.Add(item.ReleaseDate);
            }
        }

        public async Task GetAllStudiosName(List<Anime> animes)
        {
            _studios = new List<string>();

            foreach (var item in animes)
            {
                _studios.Add(item.Studio.Name);
            }
        }

        public async Task GetAllNumberOfEpisodes(List<Anime> animes)
        {
            _numbersOfEpisode = new List<int>();

            foreach (var item in animes)
            {
                _numbersOfEpisode.Add(item.NumberOfEpisodes);
            }
        }

        public async Task GetAllGenres(List<Anime> animes)
        {
            _genres = new List<string>();

            foreach (var item in animes)
            {
                _genres = _genres.Concat(item.Genres.Select(g => g.Name).ToList()).ToList();
            }
        }

        public async Task SoringForGenre()
        {
            ISortAnime sortAnime = new SearchForGenre();
            ObservableCollection<PosterRow> posters = new ObservableCollection<PosterRow>();
            Filter filter = Filter.Builder.AddGenres(_genresOfFilter).Build();

            IAnimeRepository animeRepository = new AnimeRepository("Host=localhost;Username=ed;Password=22041977;Database=AniBASED");
            AnimeService animeService = new AnimeService(animeRepository);
            List<Anime> animes = animeService.GetAllAnime().Result;

            List<Anime> animesSorted = sortAnime.SearchAnime(animes, filter);

            foreach (var item in animesSorted)
            {
                PosterVM posterVM = new PosterVM(item);
                posters.Add(new PosterRow(posterVM));
            }
            _mainVM.WindowAnimesVM.Posters = posters;
        }

        #endregion

        public NewsBlockVM(MainVM mainVM)
        {
            _mainVM = mainVM;
            _genresOfFilter = new List<Genre>();
        }
    }
}