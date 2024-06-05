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

namespace AniBased.ViewModel
{
    internal class EntryVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

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
            get => new RelayCommand((param) => OnEntry(param),
                                    (_) => CanEntry());
        }

        private async void OnEntry(object parameter)
        {
            _mainVM.StartVM = _mainVM.HomeVM;
            _mainVM.SetStartLocation();
            _mainVM.HomeVM.MakeFullScreen();
            await _mainVM.PagesAnimeVM.InitializeComponent();
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
