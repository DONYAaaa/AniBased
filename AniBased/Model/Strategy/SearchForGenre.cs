using AniBased.Model.BLL.Entities;
using AniBased.Model.Strategy.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.Strategy
{
    internal class SearchForGenre : ISortAnime
    {
        public List<Anime> SearchAnime(List<Anime> animes, Filter filter)
        {
            List<Anime> foundAnime = new List<Anime>();

            foreach (Anime anime in animes)
            {
                foreach (Genre genre in filter.Genres)
                {
                    if (anime.Genres.Any(g => g.Name == genre.Name))
                    {
                        foundAnime.Add(anime);
                        break; // Найдено совпадение с жанром, переходим к следующему аниме
                    }
                }
            }

            return foundAnime;
        }
    }
}
