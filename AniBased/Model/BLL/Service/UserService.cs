using AniBased.Mapper;
using AniBased.Model.BLL.Entities;
using AniBased.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Service
{
    internal class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var userEntities = await _userRepository.GetByIdAsync(id);
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
                await _userRepository.AddAsync(userEntities);
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
                _userRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
