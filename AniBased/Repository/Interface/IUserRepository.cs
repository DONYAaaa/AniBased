using AniBased.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Repository.Interface
{
    internal interface IUserRepository
    {
        public Task<UserDAL> GetByNameAsync(string name);
        public Task AddAsync(UserDAL userDAL);
        public Task DeleteAsync(int id);
    }
}
