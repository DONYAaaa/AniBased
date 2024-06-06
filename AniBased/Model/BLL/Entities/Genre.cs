using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Entities
{
    internal class Genre
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }

        public Genre(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
