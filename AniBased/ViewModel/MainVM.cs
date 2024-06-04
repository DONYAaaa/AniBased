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

        private BaseVM _startVM;
        public BaseVM StartVM { get => _startVM; set => Set(ref _startVM, value); }



        #endregion

        public MainVM() 
        {
            _startVM = new EntryVM(this);
        } 
    }
}
