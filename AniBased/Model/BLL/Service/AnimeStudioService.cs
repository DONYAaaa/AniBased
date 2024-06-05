using AniBased.DAL;
using AniBased.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Service
{
    internal class AnimeStudioService
    {
        private readonly IAnimeStudioRepository _animeStudioRepository;

        public AnimeStudioService(IAnimeStudioRepository animeStudioRepository)
        {
            _animeStudioRepository = animeStudioRepository;
        }

        public async Task AddInstallationWorkerAsync(AnimeDAL animeDAL, StudioDAL studioDAL)
        {
            try
            {
                await _animeStudioRepository.AddAsync(animeDAL, studioDAL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAnimeStudioAsync(int id)
        {
            try
            {
                await _animeStudioRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
