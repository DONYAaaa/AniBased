using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Entities
{
    internal class Filter
    {
        public int ReleaseDate { get; private set; }
        public int NumberOfEpisodes { get; private set; }
        public List<Genre> Genres { get; private set; }

        public static FilterBuilder Builder => new FilterBuilder();

        private Filter() { Genres = new List<Genre>(); }


        public class FilterBuilder
        {
            Filter filter;

            public FilterBuilder()
            {
                filter = new Filter();
            }

            public FilterBuilder(Filter filter)
            {
                this.filter = filter;
            }

            public FilterBuilder AddGenre(Genre genre)
            {
                filter.Genres.Add(genre);
                return this;
            }


            public FilterBuilder AddGenres(List<Genre> genres)
            {
                filter.Genres = filter.Genres.Concat(genres).ToList();
                return this;
            }

            public FilterBuilder AddNumberOfEpisode(int numberOfEpisode)
            {
                filter.NumberOfEpisodes = numberOfEpisode;
                return this;
            }

            public FilterBuilder AddReleaseData(int releaseData)
            {
                filter.ReleaseDate = releaseData;
                return this;
            }

            public Filter Build()
            {
                return filter;
            }
        }

    }
}
