using AniBased.DAL;
using AniBased.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Service
{
    internal class PageAnimeService
    {
        private readonly IPageAnimeRepository _pageAnimeRepository;

        public PageAnimeService(IPageAnimeRepository pageAnimeRepository)
        {
            _pageAnimeRepository = pageAnimeRepository;
        }

        public async Task AddInstallationWorkerAsync(PageOfAnimeDAL pageDal, AnimeDAL animeDAL)
        {
            try
            {
                await _pageAnimeRepository.AddAsync(pageDal, animeDAL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeletePageAnimeAsync(int id)
        {
            try
            {
                await _pageAnimeRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
