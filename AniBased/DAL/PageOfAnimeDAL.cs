using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.DAL
{
    internal class PageOfAnimeDAL
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AnimeDAL> AnimeDAL { get; set; }
    }
}
