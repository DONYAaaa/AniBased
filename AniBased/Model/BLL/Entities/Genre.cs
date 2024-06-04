using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Entities
{
    internal class Genre
    {
        public string Name { get; }
        public string Description { get; }

        public Genre(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
