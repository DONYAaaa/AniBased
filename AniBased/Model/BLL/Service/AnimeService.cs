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

        public Anime GetAnimeById(int id)
        {
            try
            {
                var animeEntities = _animeRepository.GetByid(id);
                return animeEntities?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateAnime(Anime anime)
        {
            try
            {
                var animeEntities = anime.ToDAL();
                _animeRepository.Add(animeEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteAnime(int id)
        {
            try
            {
                _animeRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
