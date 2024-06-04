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

namespace AniBased.ViewModel
{
    internal class EntryVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА
        
        private string _name;
        public string Name { get => _name; set => Set(ref _name, value); }

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

        #region Развернуть / скрыть пароль

        public ICommand TogglePasswordVisibilityCommand
        {
            get => new RelayCommand((param) => TogglePasswordVisibility(param),
                                    (_) => CanTogglePasswordVisibility());
        }

        private async void TogglePasswordVisibility(object parameter)
        {
            var values = (object[])parameter;
            var passwordBox = values[0] as PasswordBox;
            var textBox = values[1] as TextBox;

            if (passwordBox.Visibility == Visibility.Visible)
            {
                textBox.Text = passwordBox.Password;
                passwordBox.Visibility = Visibility.Collapsed;
                textBox.Visibility = Visibility.Visible;
            }
            else
            {
                passwordBox.Password = textBox.Text;
                textBox.Visibility = Visibility.Collapsed;
                passwordBox.Visibility = Visibility.Visible;
            }
        }

        private bool CanTogglePasswordVisibility()
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
        }
    }
}
