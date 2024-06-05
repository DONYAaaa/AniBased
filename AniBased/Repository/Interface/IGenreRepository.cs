using AniBased.DAL;
using AniBased.Model.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Repository.Interface
{
    internal interface IGenreRepository
    {
        public Task<GenreDAL> GetByIdAsync(int id);
        public Task AddAsync(GenreDAL pageOfAnimeDAL);
        public Task DeleteAsync(int id);
    }
}
