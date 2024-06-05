using AniBased.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Repository.Interface
{
    internal interface IAnimeRepository
    {
        public AnimeDAL GetByid(int id);
        public void Add(AnimeDAL animeDAL);
        public void Delete(int id);
    }
}
