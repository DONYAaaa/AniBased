using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Entities
{
    internal class PageOfAnime
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public List<Anime> Animes { get; }

        public PageOfAnime(int id, string name, List<Anime> animes)
        {
            Id = id;
            Name = name;
            Animes = animes;
        }

        public void AddAnime(Anime anime)
        {
            if (!IsAnimeContains(anime)) { Animes.Add(anime); }
        }

        public void RemoveAnime(Anime anime)
        {
            if (IsAnimeContains(anime)) { Animes.Remove(anime); }
        }

        private bool IsAnimeNotNull(Anime anime)
        {
            if (anime == null) return false; else return true;
        }

        private bool IsAnimeContains(Anime anime)
        {
            if (IsAnimeNotNull(anime))
                if (Animes.Contains(anime)) return true; else return false;
            else throw new ArgumentNullException();
        }
    }
}
