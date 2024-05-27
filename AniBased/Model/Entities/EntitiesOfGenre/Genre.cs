using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.Entities.EntitiesOfGenre
{
    internal class Genre
    {
        public string Name { get; }

        public Genre(string name)
        {
            Name = name;
        }
    }
}
