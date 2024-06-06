using AniBased.Infastructure.Command;
using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using AniBased.View.Resource;
using AniBased.Model.BLL.Service;
using AniBased.Repository.Interface;
using AniBased.Repository;
using AniBased.Model.BLL.Entities;
using AniBased.ViewModel.Home;
using AniBased.Model;
using System.Collections.ObjectModel;

namespace AniBased.ViewModel
{
    internal class EntryVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        private string connectionString = "Host=localhost;Username=ed;Password=22041977;Database=AniBASED";

        #endregion

        #region СВОЙСТВА
        private PasswordVM _passwordVM;
        public PasswordVM PasswordVM { get=> _passwordVM; set => Set(ref _passwordVM, value); }

        private string _name;
        public string Name { get => _name; set => Set(ref _name, value); }


        private string _password;
        public string Password { get => _password; set => Set(ref _password, value); }


        #endregion

        #region КОМАНДЫ

        #region Открыть окно регистрации

        public ICommand OpenRegistry
        {
            get => new RelayCommand((_) => OpenRegistyWindow(),
                                    (_) => CanOpenRegistyWindow());
        }

        private async void OpenRegistyWindow()
        {
            _mainVM.StartVM = _mainVM.RegistryVM;
        }

        private bool CanOpenRegistyWindow()
        {
            return true;
        }

        #endregion

        #region Войти

        public ICommand Entry
        {
            get => new AsyncRelayCommand(OnEntry, CanEntry);
        }

        private async Task OnEntry()
        {
            IUserRepository userRepository = new UserRepository(connectionString);
            UserService userService = new UserService(userRepository);
            _mainVM.User = null;
            _mainVM.User = (userService.GetUserByName(Name).Result);

            if(_mainVM.User != null)
            {
                await GetAllPosters();
                await Run();
            }
        }

        public async Task GetAllPosters()
        {
            ObservableCollection<PosterRow> posters= new ObservableCollection<PosterRow>();

            IAnimeRepository animeRepository = new AnimeRepository(connectionString);
            AnimeService animeService = new AnimeService(animeRepository);
            List<Anime> animes = animeService.GetAllAnime().Result;
            foreach (var item in animes)
            {
                PosterVM posterVM = new PosterVM(item);
                posters.Add(new PosterRow(posterVM));
            }
            _mainVM.WindowAnimesVM.Posters = posters;
        }

        private async Task Run()
        {
            _mainVM.StartVM = _mainVM.HomeVM;
            _mainVM.SetStartLocation();
            _mainVM.HomeVM.MakeFullScreen();
            _mainVM.PagesAnimeVM.InitializeComponent();
        }

        private bool CanEntry()
        {
            return true;
        }

        #endregion

        #endregion

        #region МЕТОДЫ


        #endregion

        public EntryVM(MainVM mainVM) 
        {
            _mainVM = mainVM;
            _passwordVM = new PasswordVM(_mainVM);
        }
    }
}
