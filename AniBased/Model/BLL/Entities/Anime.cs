using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Entities
{
    internal class Anime
    {
        public int Id { get; private set; } //TODO оставить ли ID?
        public string Name { get; private set; }
        public int ReleaseDate { get; private set; }
        public int NumberOfEpisodes { get; private set; }
        public List<Genre> Genres { get; private set; }
        public string Description { get; private set; }
        public string LinkToView { get; private set; } //TODO нужно ли открывать?


        public static AnimeBuilder Builder => new AnimeBuilder();


        private Anime() { Genres = new List<Genre>(); }


        public class AnimeBuilder
        {
            Anime anime;

            public AnimeBuilder()
            {
                anime = new Anime();
            }

            public NameAnimeBuilder AddId(int Id)
            {
                anime.Id = Id;
                return new NameAnimeBuilder(anime);
            }



            public class NameAnimeBuilder
            {
                public Anime anime;

                public NameAnimeBuilder(Anime anime)
                {
                    this.anime = anime;
                }

                public FinalAnimeBuilder AddName(string Name)
                {
                    anime.Name = Name;
                    return new FinalAnimeBuilder(anime);
                }


                public class FinalAnimeBuilder
                {
                    public Anime anime;

                    public FinalAnimeBuilder(Anime anime)
                    {
                        this.anime = anime;
                    }

                    public FinalAnimeBuilder AddReleaseDate(int ReleaseDate)
                    {
                        anime.ReleaseDate = ReleaseDate;
                        return this;
                    }

                    public FinalAnimeBuilder AddNumberOfEpisodes(int NumberOfEpisodes)
                    {
                        anime.NumberOfEpisodes = NumberOfEpisodes;
                        return this;
                    }

                    public virtual FinalAnimeBuilder AddGenre(Genre Ganre)
                    {
                        anime.Genres.Add(Ganre);
                        return this;
                    }

                    public FinalAnimeBuilder AddDescription(string Description)
                    {
                        anime.Description = Description;
                        return this;
                    }

                    public FinalAnimeBuilder AddLinkToView(string LinkToView)
                    {
                        anime.LinkToView = LinkToView;
                        return this;
                    }

                    public Anime Build()
                    {
                        return anime;
                    }
                }
            }
        }
    }
}
