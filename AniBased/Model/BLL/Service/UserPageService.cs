using AniBased.DAL;
using AniBased.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Service
{
    internal class UserPageService
    {
        private readonly IUserPageRepository _userPageRepository;

        public UserPageService(IUserPageRepository userPageRepository)
        {
            _userPageRepository = userPageRepository;
        }

        public async Task AddInstallationWorkerAsync(UserDAL userDAL, PageOfAnimeDAL pageDal)
        {
            try
            {
                await _userPageRepository.AddAsync(userDAL, pageDal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteUserPageAsync(int id)
        {
            try
            {
                await _userPageRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
