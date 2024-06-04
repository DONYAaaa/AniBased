using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        #endregion

        public RegistryVM(MainVM mainVM)
        {
            _mainVM = mainVM;
        }
    }
}
