using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Media3D;

namespace AniBased.ViewModel
{
    internal class MainVM : BaseVM
    {

        #region СВОЙСТВА VM

        private EntryVM _entryVM;
        public EntryVM EntryVM { get => _entryVM; set => Set(ref _entryVM, value); }



        #endregion

        public MainVM() 
        {
            _entryVM = new EntryVM(this);
        } 
    }
}
