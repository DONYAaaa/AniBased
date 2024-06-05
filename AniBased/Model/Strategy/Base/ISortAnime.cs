using AniBased.Model.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.Strategy.Base
{
    internal interface ISortAnime
    {
        public List<Anime> SearchAnime(List<Anime> animes, Filter filter);
    }
}
