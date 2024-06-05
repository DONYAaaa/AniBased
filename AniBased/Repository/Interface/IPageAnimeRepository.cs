using AniBased.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Repository.Interface
{
    internal interface IPageAnimeRepository
    {
        public Task AddAsync(PageOfAnimeDAL pageDAL, AnimeDAL animeDAL);
        public Task DeleteAsync(int id);
    }
}
