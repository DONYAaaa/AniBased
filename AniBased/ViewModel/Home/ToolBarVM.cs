using AniBased.Infastructure.Command;
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
    internal class ToolBarVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        #endregion

        #region КОМАНДЫ

        #region Закрыть окно

        public ICommand CloseWindowCommand
        {
            get => new RelayCommand((_) => CloseWindow(),
                                    (_) => CanTogglePasswordVisibility());
        }

        private void CloseWindow()
        {
            Application.Current.Shutdown();
        }

        private bool CanTogglePasswordVisibility()
        {
            return true;
        }

        #endregion


        #endregion

        #region МЕТОДЫ


        #endregion

        public ToolBarVM(MainVM mainVM)
        {
            _mainVM = mainVM;
        }
    }
}
