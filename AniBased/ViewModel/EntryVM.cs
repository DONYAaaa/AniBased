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
        private MainVM _mainVM;

        public EntryVM(MainVM mainVM) 
        {
            _mainVM = mainVM;
        }
    }
}
