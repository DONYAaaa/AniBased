using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.ViewModel
{
    internal class EntryVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА
        
        private string _name;
        public string Name;

        #endregion

        #region КОМАНДЫ


        #endregion

        #region МЕТОДЫ


        #endregion

        public EntryVM(MainVM mainVM) 
        {
            _mainVM = mainVM;
        }
    }
}
