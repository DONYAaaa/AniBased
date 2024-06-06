using AniBased.Infastructure.Command;
using AniBased.ViewModel.Base;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AniBased.ViewModel.Home
{
    class NavigationCommandVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        #endregion

        #region КОМАНДЫ

        #region Открыть профиль

        public ICommand ProfileOpenCommand
        {
            get => new AsyncRelayCommand(OnProfileOpenCommand, CanProfileOpenCommand);
        }

        private async Task OnProfileOpenCommand()
        {
            _mainVM.StartVM = _mainVM.MainProfileVM;
            _mainVM.MainProfileVM.MakeFullScreen();
        }

        private bool CanProfileOpenCommand()
        {
            if (_mainVM.StartVM == _mainVM.HomeVM)
                return true;
            else return false;
        }

        #endregion

        #region Открыть главную

        public ICommand HomeOpenCommand
        {
            get => new AsyncRelayCommand(OnHomeOpenCommand, CanHomeOpenCommand);
        }

        private async Task OnHomeOpenCommand()
        {
            _mainVM.StartVM = _mainVM.HomeVM;
        }

        private bool CanHomeOpenCommand()
        {
            if (_mainVM.StartVM == _mainVM.MainProfileVM)
                return true;
            else return false;
        }

        #endregion

        #endregion

        #region МЕТОДЫ

        #endregion

        public NavigationCommandVM(MainVM mainVM)
        {
            _mainVM = mainVM;
        }
    }
}