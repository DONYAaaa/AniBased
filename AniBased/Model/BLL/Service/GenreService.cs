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
    internal class GenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Genre> GetGenreById(int id)
        {
            try
            {
                var genreEntities = await _genreRepository.GetByIdAsync(id);
                return genreEntities?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateGenre(Genre genre)
        {
                var genreEntities = genre.ToDAL();
                await _genreRepository.AddAsync(genreEntities);
        }

        public async Task DeleteGenre(int id)
        {
            try
            {
                _genreRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
