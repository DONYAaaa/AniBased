using AniBased.DAL;
using AniBased.Model.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Mapper
{
    internal static class GenreMapper
    {
        public static Genre ToBLL(this GenreDAL entity)
        {
            return new Genre(entity.Name, entity.Description);
        }

        public static GenreDAL ToDAL(this Genre entity)
        {
            return new GenreDAL
            {
                Name = entity.Name,
                Description = entity.Description,
            };
        }
    }
}
