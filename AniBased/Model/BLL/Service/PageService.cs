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
    internal class PageService
    {
        private readonly IPageRepository _pageRepository;

        public PageService(IPageRepository userRepository)
        {
            _pageRepository = userRepository;
        }

        public async Task<PageOfAnime> GetPageById(int id)
        {
            try
            {
                var pageEntities = await _pageRepository.GetByIdAsync(id);
                return pageEntities?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreatePage(PageOfAnime pageOfAnime)
        {
            try
            {
                var pageOfAnimeEntities = pageOfAnime.ToDAL();
                await _pageRepository.AddAsync(pageOfAnimeEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeletePage(int id)
        {
            try
            {
                _pageRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
