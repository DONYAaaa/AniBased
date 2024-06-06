using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AniBased.Model.BLL.Entities
{
    internal class Anime
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateOnly ReleaseDate { get; private set; }
        public int NumberOfEpisodes { get; private set; }
        public List<Genre> Genres { get; private set; }
        public string Description { get; private set; }
        public string LinkToView { get; private set; }
        public string Dubbing { get; private set; }
        public Studio Studio { get; private set; }
        public int AgeRestriction { get; private set; }
        public Image Image { get; private set; }


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

                    public FinalAnimeBuilder AddReleaseDate(DateOnly ReleaseDate)
                    {
                        anime.ReleaseDate = ReleaseDate;
                        return this;
                    }

                    public FinalAnimeBuilder AddNumberOfEpisodes(int NumberOfEpisodes)
                    {
                        anime.NumberOfEpisodes = NumberOfEpisodes;
                        return this;
                    }

                    public FinalAnimeBuilder AddAgeRestriction(int AgeRestriction)
                    {
                        anime.AgeRestriction = AgeRestriction;
                        return this;
                    }

                    public virtual FinalAnimeBuilder AddGenre(Genre Genre)
                    {
                        if (Genre != null)
                        {
                            anime.Genres.Add(Genre);
                        }
                        return this;
                    }
                    public virtual FinalAnimeBuilder AddGenres(List<Genre> Genre)
                    {
                        anime.Genres = anime.Genres.Concat(Genre).ToList();
                        return this;
                    }


                    public virtual FinalAnimeBuilder AddImage(Image image)
                    {
                        anime.Image = image;
                        return this;
                    }

                    public virtual FinalAnimeBuilder AddStudio(Studio studio)
                    {
                        anime.Studio = studio;
                        return this;
                    }

                    public FinalAnimeBuilder AddDescription(string Description)
                    {
                        anime.Description = Description;
                        return this;
                    }

                    public FinalAnimeBuilder AddDubbing(string Dubbing)
                    {
                        anime.Dubbing = Dubbing;
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
