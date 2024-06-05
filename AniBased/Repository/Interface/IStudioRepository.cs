using AniBased.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Repository.Interface
{
    internal interface IStudioRepository
    {
        public Task<StudioDAL> GetByIdAsync(int id);
        public Task AddAsync(StudioDAL pageOfAnimeDAL);
        public Task DeleteAsync(int id);
    }
}
