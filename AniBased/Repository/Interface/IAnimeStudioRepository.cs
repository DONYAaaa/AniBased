using AniBased.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Repository.Interface
{
    internal interface IAnimeStudioRepository
    {
        public Task AddAsync(AnimeDAL animeDAL, StudioDAL studioDAL);
        public Task DeleteAsync(int id);
    }
}
