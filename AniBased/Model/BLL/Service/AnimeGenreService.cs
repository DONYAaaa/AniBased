using AniBased.DAL;
using AniBased.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Service
{
    internal class AnimeGenreService
    {
        private readonly IAnimeGenreRepository _animeGenreRepository;

        public AnimeGenreService(IAnimeGenreRepository animeGenreRepository)
        {
            _animeGenreRepository = animeGenreRepository;
        }

        public async Task AddInstallationWorkerAsync(AnimeDAL animeDAL, GenreDAL genreDAL)
        {
            try
            {
                await _animeGenreRepository.AddAsync(animeDAL, genreDAL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAnimeGenreAsync(int id)
        {
            try
            {
                await _animeGenreRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
