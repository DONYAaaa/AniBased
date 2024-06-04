using AniBased.Infastructure.Command;
using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace AniBased.ViewModel
{
    internal class RegistryVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        private string _name;
        public string Name { get => _name; set => Set(ref _name, value); }

        #endregion

        #region КОМАНДЫ


        #endregion

        #region МЕТОДЫ

        #region Открыть окно входа

        public ICommand OpenEntry
        {
            get => new RelayCommand((_) => OpenEntryWindow(),
                                    (_) => CanOpenEntryWindow());
        }

        private async void OpenEntryWindow()
        {
            _mainVM.StartVM = _mainVM.EntryVM;
        }

        private bool CanOpenEntryWindow()
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

        public RegistryVM(MainVM mainVM)
        {
            _mainVM = mainVM;
        }
    }
}
