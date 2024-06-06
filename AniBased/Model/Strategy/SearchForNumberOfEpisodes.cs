using AniBased.Model.BLL.Entities;
using AniBased.Model.Strategy.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.Strategy
{
    public class SearchForNumberOfEpisodes : ISortAnime
    {
        public List<Anime> SearchAnime(List<Anime> animes, Filter filter)
        {
            List<Anime> foundAnime = new List<Anime>();

            foreach (Anime anime in animes)
            {
                if (anime.NumberOfEpisodes == (filter.NumberOfEpisodes))
                {
                    foundAnime.Add(anime);
                }
            }

            return foundAnime;
        }
    }
}
