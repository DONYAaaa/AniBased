using AniBased.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Repository.Interface
{
    internal interface IAnimeRepository
    {
        public Task<AnimeDAL> GetByIdAsync(int id);
        public Task<List<AnimeDAL>> GetAllAsync();
        public Task AddAsync(AnimeDAL animeDAL);
        public Task DeleteAsync(int id);
    }
}
