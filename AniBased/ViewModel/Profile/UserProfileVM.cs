using AniBased.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.ViewModel.Profile
{
    class UserProfileVM : BaseVM
    {
        #region ПОЛЯ

        private readonly MainVM _mainVM;

        #endregion

        #region СВОЙСТВА

        private string _nickName;
        public string Nicname { get=>_nickName; set=>Set(ref _nickName, value); }

        private DateOnly _dateOfBirth;
        public DateOnly DateOfBirth { get => _dateOfBirth; set => Set(ref _dateOfBirth, value); }

        private string _mail;
        public string Mail { get => _mail; set => Set(ref _mail, value); }

        #endregion

        #region КОМАНДЫ
        #endregion

        #region МЕТОДЫ
            
        public async Task Refresh()
        {
            _nickName = _mainVM.User.Name;
            _dateOfBirth = _mainVM.User.DateOfBirth;
            _mail = _mainVM.User.Email;
        }
            
        #endregion

        public UserProfileVM(MainVM mainVM)
        {
            _mainVM = mainVM;
        }
    }
}
