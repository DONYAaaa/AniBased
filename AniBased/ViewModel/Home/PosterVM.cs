using AniBased.Model.BLL.Entities;
using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Bogus.DataSets.Name;

namespace AniBased.ViewModel.Home
{
    class PosterVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        private Image _image;
        public Image Image { get => _image; set => Set(ref _image, value); }

        private string _nameOfAnime;
        public string NameOfAnime { get => _nameOfAnime; set => Set(ref _nameOfAnime, value); }

        private string _genres;
        public string Genres { get => _genres; set => Set(ref _genres, value); }

        private string _country;
        public string Country { get => _country; set => Set(ref _country, value); }

        private string _studio;
        public string Studio { get => _studio; set => Set(ref _studio, value); }

        private string _yearOfRelease;
        public string YearOfRelease { get => _yearOfRelease; set => Set(ref _yearOfRelease, value); }

        #endregion

        #region КОМАНДЫ

        #endregion

        #region МЕТОДЫ

        #endregion

        public PosterVM(MainVM mainVM)
        {
            _mainVM = mainVM;
        }

        public PosterVM(Anime anime)
        {
            NameOfAnime = anime.Name;
            Genres = string.Join(", ", anime.Genres.Select(g => g.Name));
            Country = anime.NumberOfEpisodes.ToString();
            Studio = anime.Studio.Name;
            YearOfRelease = anime.ReleaseDate.ToString();
        }
    }
}
