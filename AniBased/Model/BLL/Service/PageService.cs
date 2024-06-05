using AniBased.Model.BLL.Entities;
using AniBased.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Service
{
    internal class PageService
    {
        private readonly IPageRepository _pageRepository;

        public PageService(IPageRepository userRepository)
        {
            _pageRepository = userRepository;
        }

        public async Task<User> GetPageById(int id)
        {
            try
            {
                var pageEntities = await _pageRepository.GetByIdAsync(id);
                return userEntities?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateUser(User user)
        {
            try
            {
                var userEntities = user.ToDAL();
                await _pageRepository.AddAsync(userEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                _pageRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
