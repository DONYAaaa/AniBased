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
    internal class StudioService
    {
        private readonly IStudioRepository _studioRepository;

        public StudioService(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        public async Task<Studio> GetStudioById(int id)
        {
            try
            {
                var studioEntities = await _studioRepository.GetByIdAsync(id);
                return studioEntities?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateStudio(Studio studio)
        {
            try
            {
                var studioEntities = studio.ToDAL();
                await _studioRepository.AddAsync(studioEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteStudio(int id)
        {
            try
            {
                _studioRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
