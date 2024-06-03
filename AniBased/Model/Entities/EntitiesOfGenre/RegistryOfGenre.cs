using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.Entities.EntitiesOfGenre
{
    internal class RegistryOfGenre
    {
        public List<Genre> Genres { get; }

        public void AddGenre(Genre genre)
        {
            if (!IsGenreContains(genre)) { Genres.Add(genre); }
        }

        public void RemoveGenre(Genre genre)
        {
            if (IsGenreContains(genre)) { Genres.Remove(genre); }
        }

        private bool IsGenreNotNull(Genre genre)
        {
            if (genre == null) return false; else return true;
        }

        private bool IsGenreContains(Genre genre)
        {
            if (IsGenreNotNull(genre))
                if (Genres.Contains(genre)) return true; else return false;
            else throw new ArgumentNullException();
        }
    }
}
