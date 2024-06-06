using AniBased.Model.BLL.Entities;
using AniBased.Model.Strategy;
using AniBased.Model.Strategy.Base;
using System.Reflection;

namespace AniBASEDTest
{
    public class SortingTest
    {
        [Fact]
        public void Sort_Anime_Poster_For_One_Genre()
        {

            // Arrange
            List<Anime> animes = new List<Anime>()
            {
                Anime.Builder.AddId(1)
                             .AddName("Naruto")
                             .AddDescription("as as  w qf q a s a")
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .Build(),

                Anime.Builder.AddId(2)
                             .AddName("Artorias")
                             .AddGenre(new Genre("name1"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(3)
                             .AddName("Summer Day")
                             .AddGenre(new Genre("name1"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(4)
                             .AddName("Your April Lie")
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(5)
                             .AddName("Bocu No Pico")
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(6)
                             .AddName("Bocu No Hero Academy")
                             .AddGenre(new Genre("name5"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name4"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),
            };

            // Act
            ISortAnime sortAnime = new SearchForGenre();
            Genre name1 = new Genre("name1");
            Filter filter = Filter.Builder.AddGenre(name1).Build();
            List<Anime> actualAnimes = sortAnime.SearchAnime(animes, filter);
            List<Anime> expectedAnimes = new List<Anime>()
            {
                Anime.Builder.AddId(2)
                             .AddName("Artorias")
                             .AddGenre(new Genre("name1"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(3)
                             .AddName("Summer Day")
                             .AddGenre(new Genre("name1"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),
            };

            // Assert
            Assert.Equal(expectedAnimes.Select(e => e.Id).ToList(), actualAnimes.Select(e => e.Id).ToList());
        }

        [Fact]
        public void Sorting_By_More_Than_One_Genre()
        {

            // Arrange
            List<Anime> animes = new List<Anime>()
            {
                Anime.Builder.AddId(1)
                             .AddName("Naruto")
                             .AddDescription("as as  w qf q a s a")
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .Build(),

                Anime.Builder.AddId(2)
                             .AddName("Artorias")
                             .AddGenre(new Genre("name1"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(3)
                             .AddName("Summer Day")
                             .AddGenre(new Genre("name1"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(4)
                             .AddName("Your April Lie")
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(5)
                             .AddName("Bocu No Pico")
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(6)
                             .AddName("Bocu No Hero Academy")
                             .AddGenre(new Genre("name5"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name4"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),
            };

            // Act
            ISortAnime sortAnime = new SearchForGenre();
            List<Genre> genres = new List<Genre>()
            {
                new Genre("name5"),
                new Genre("name2"),
                new Genre("name4")
            };
            Filter filter = Filter.Builder.AddGenres(genres).Build();
            List<Anime> actualAnimes = sortAnime.SearchAnime(animes, filter);
            List<Anime> expectedAnimes = new List<Anime>()
            {
                              Anime.Builder.AddId(1)
                             .AddName("Naruto")
                             .AddDescription("as as  w qf q a s a")
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .Build(),

                Anime.Builder.AddId(2)
                             .AddName("Artorias")
                             .AddGenre(new Genre("name1"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(5)
                             .AddName("Bocu No Pico")
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(6)
                             .AddName("Bocu No Hero Academy")
                             .AddGenre(new Genre("name5"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name4"))
                             .AddDescription("as as  w qf q a s a")
                             .Build()
            };

            // Assert
            Assert.Equal(expectedAnimes.Select(e => e.Id).ToList(), actualAnimes.Select(e => e.Id).ToList());
        }

        [Fact]
        public void Checking_The_Register_Registration()
        {

            // Arrange
            List<Anime> animes = new List<Anime>()
            {
                Anime.Builder.AddId(1)
                             .AddName("Naruto")
                             .AddDescription("as as  w qf q a s a")
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .Build(),

                Anime.Builder.AddId(2)
                             .AddName("Artorias")
                             .AddGenre(new Genre("name1"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(3)
                             .AddName("Summer Day")
                             .AddGenre(new Genre("name1"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(4)
                             .AddName("Your April Lie")
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(5)
                             .AddName("Bocu No Pico")
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(6)
                             .AddName("Bocu No Hero Academy")
                             .AddGenre(new Genre("name5"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name4"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),
            };

            // Act
            ISortAnime sortAnime = new SearchForGenre();
            List<Genre> genres = new List<Genre>()
            {
                new Genre("NaMe5")
            };
            Filter filter = Filter.Builder.AddGenres(genres).Build();
            List<Anime> actualAnimes = sortAnime.SearchAnime(animes, filter);
            List<Anime> expectedAnimes = new List<Anime>()
            {           

                Anime.Builder.AddId(6)
                             .AddName("Bocu No Hero Academy")
                             .AddGenre(new Genre("name5"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name4"))
                             .AddDescription("as as  w qf q a s a")
                             .Build()
            };

            // Assert
            Assert.Equal(expectedAnimes.Select(e => e.Id).ToList(), actualAnimes.Select(e => e.Id).ToList());
        }

        [Fact]
        public void Checking_With_A_Missing_Genre()
        {

            // Arrange
            List<Anime> animes = new List<Anime>()
            {
                Anime.Builder.AddId(1)
                             .AddName("Naruto")
                             .AddDescription("as as  w qf q a s a")
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .Build(),

                Anime.Builder.AddId(2)
                             .AddName("Artorias")
                             .AddGenre(new Genre("name1"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(3)
                             .AddName("Summer Day")
                             .AddGenre(new Genre("name1"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(4)
                             .AddName("Your April Lie")
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(5)
                             .AddName("Bocu No Pico")
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name3"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),

                Anime.Builder.AddId(6)
                             .AddName("Bocu No Hero Academy")
                             .AddGenre(new Genre("name5"))
                             .AddGenre(new Genre("name2"))
                             .AddGenre(new Genre("name4"))
                             .AddDescription("as as  w qf q a s a")
                             .Build(),
            };

            // Act
            ISortAnime sortAnime = new SearchForGenre();
            List<Genre> genres = new List<Genre>()
            {
                new Genre("DateBayou")
            };
            Filter filter = Filter.Builder.AddGenres(genres).Build();
            List<Anime> actualAnimes = sortAnime.SearchAnime(animes, filter);
            List<Anime> expectedAnimes = new List<Anime>()
            {
            };

            // Assert
            Assert.Equal(expectedAnimes.Select(e => e.Id).ToList(), actualAnimes.Select(e => e.Id).ToList());
        }
    }
}
