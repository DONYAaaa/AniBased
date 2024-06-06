using AniBased.Model.BLL.Entities;
using AniBased.Repository.Interface;
using AniBased.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Service
{
    internal class AnimeService
    {
        private readonly IAnimeRepository _animeRepository;

        public AnimeService(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<Anime> GetAnimeById(int id)
        {
            try
            {
                var animeEntities = await _animeRepository.GetByIdAsync(id);
                return animeEntities?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Anime>> GetAllAnime()
        {
            try 
            {
                var animesEntities = await _animeRepository.GetAllAsync();
                return animesEntities?.ToListBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateAnime(Anime anime)
        {
            try
            {
                var animeEntities = anime.ToDAL();
                await _animeRepository.AddAsync(animeEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAnime(int id)
        {
            try
            {
                _animeRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
