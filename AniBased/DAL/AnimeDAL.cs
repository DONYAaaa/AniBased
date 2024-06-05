using AniBased.Model.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.DAL
{
    internal class AnimeDAL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int NumberOfEpisodes { get; set; }
        public string Description { get; set; }
        public int AgeRestriction { get; set; }
        public string Dubbing { get; set; }
        public string LinkToView { get; set; }
        public byte[] Poster { get; set; }
        public List<GenreDAL> Genres { get; set; }
        public StudioDAL Studio { get; set; }
    }

}
