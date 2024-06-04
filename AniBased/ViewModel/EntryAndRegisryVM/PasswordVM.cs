using AniBased.Infastructure.Command;
using AniBased.View.Resource;
using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace AniBased.ViewModel
{
    internal class PasswordVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        private string _password;
        public string Password { get; set; }

        #endregion

        #region КОМАНДЫ

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

        public PasswordVM(MainVM mainVM)
        {
            _mainVM = mainVM;
        }
    }
}
