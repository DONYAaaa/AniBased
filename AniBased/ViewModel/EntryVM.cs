using AniBased.Infastructure.Command;
using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #region СДЕЛАТЬ ФОТО

        public ICommand OpenRegistry
        {
            get => new RelayCommand((_) => OpenRegistyWindow(),
                                    (_) => CanOpenRegistyWindow());
        }

        private async void OpenRegistyWindow()
        {
            _mainVM.StartVM = new RegistryVM(_mainVM);
        }

        private bool CanOpenRegistyWindow()
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
