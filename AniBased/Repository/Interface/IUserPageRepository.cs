using AniBased.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Repository.Interface
{
    internal interface IUserPageRepository
    {
        public Task AddAsync(UserDAL userDAL, PageOfAnimeDAL pageDAL);
        public Task DeleteAsync(int id);
    }
}
