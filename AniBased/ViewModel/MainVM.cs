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

        private EntryVM _entryVM;
        public EntryVM EntryVM { get => _entryVM; set => Set(ref _entryVM, value); }

        private RegistryVM _registryVM;
        public RegistryVM RegistryVM { get => _registryVM; set => Set(ref _registryVM, value); }

        private ToolBarVM _toolBarVM;
        public ToolBarVM ToolBarVM { get => _toolBarVM; set => Set(ref _toolBarVM, value); }

        #endregion

        public MainVM() 
        {
            _startVM = new EntryVM(this);
            _entryVM = (EntryVM)_startVM;
            _registryVM = new RegistryVM(this);
            _toolBarVM = new ToolBarVM(this);
        } 
    }
}
