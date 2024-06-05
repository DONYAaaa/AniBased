using AniBased.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Repository.Interface
{
    internal interface IAnimeGenreRepository
    {
        public Task AddAsync(AnimeDAL animeDAL, GenreDAL genreDAL);
        public Task DeleteAsync(int id);
    }
}
