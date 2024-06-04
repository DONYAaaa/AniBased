using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Entities
{
    internal class Library
    {
        public PageOfAnime Favorites { get; set; }
        public PageOfAnime Viewed { get; set; }
        public PageOfAnime Watching { get; set; }
        public PageOfAnime History { get; private set; }
        public PageOfAnime Planned { get; private set; }

        public List<PageOfAnime> Anime { get; set; }

        public Library()
        {
            Favorites = new PageOfAnime();
            Viewed = new PageOfAnime();
            Watching = new PageOfAnime();
            History = new PageOfAnime();
            Planned = new PageOfAnime();
        }
    }
}
