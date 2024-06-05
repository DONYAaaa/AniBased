using AniBased.DAL;
using AniBased.Model.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Mapper
{
    internal static class StudioMapper
    {
        public static Studio ToBLL(this StudioDAL entity)
        {
            return new Studio(entity.Name, entity.Description);
        }

        public static StudioDAL ToDAL(this Studio entity)
        {
            return new StudioDAL
            {
                Name = entity.Name,
                Description = entity.Description,
            };
        }
    }
}
