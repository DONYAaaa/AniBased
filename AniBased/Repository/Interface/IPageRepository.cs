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
        public Task<PageOfAnimeDAL> GetByIdAsync(int id);
        public Task AddAsync(PageOfAnimeDAL pageOfAnimeDAL);
        public Task DeleteAsync(int id);
    }
}
