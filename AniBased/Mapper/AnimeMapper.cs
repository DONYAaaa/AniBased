using AniBased.DAL;
using AniBased.Model.BLL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace AniBased.Mapper
{
    internal static class AnimeMapper
    {
        public static Anime ToBLL(this AnimeDAL entity)
        {
            return Anime.Builder.AddId(entity.Id)
                                .AddName(entity.Name)
                                .AddLinkToView(entity.LinkToView)
                                .AddNumberOfEpisodes(entity.NumberOfEpisodes)
                                .AddDescription(entity.Description)
                                .AddDubbing(entity.Dubbing)
                                .AddImage(ConvertBytesArrayToImage(entity.Poster))
                                .AddAgeRestriction(entity.AgeRestriction)
                                .AddReleaseDate(entity.ReleaseDate)
                                .AddGenres(ConvertGenresDALToGenres(entity.Genres))
                                .AddStudio(ConvertStudioDALToSudio(entity.Studio))
                                .Build();
        }

        private static Image ConvertBytesArrayToImage(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        private static List<Genre> ConvertGenresDALToGenres(List<GenreDAL> genresDAL)
        {
            List<Genre> genres = new List<Genre>();
            foreach (var item in genresDAL)
            {
                genres.Add(new Genre(item.Name, item.Description));
            }
            return genres;
        }

        private static Studio ConvertStudioDALToSudio(StudioDAL studioDAL)
        {
            Studio studio = new Studio(studioDAL.Name, studioDAL.Description);
            return studio;
        }

        public static AnimeDAL ToDAL(this Anime entity)
        {
            return new AnimeDAL
            {
                Id = entity.Id,
                Name = entity.Name,
                LinkToView = entity.LinkToView,
                NumberOfEpisodes = entity.NumberOfEpisodes,
                Description = entity.Description,
                Dubbing = entity.Dubbing,
                ReleaseDate = entity.ReleaseDate,
                AgeRestriction = entity.AgeRestriction,
                Genres = ConvertGenresToGenresDAL(entity.Genres),
                Studio = ConvertStudioToSudioDAL(entity.Studio),
                Poster = ConvertImageToByteArray(entity.Image)
            };
        }

        private static List<GenreDAL> ConvertGenresToGenresDAL(List<Genre> genres)
        {
            List<GenreDAL> genreDALs = new List<GenreDAL>();
            foreach (var item in genres)
            {
                genreDALs.Add(new GenreDAL
                {
                    Name = item.Name,
                    Description = item.Description
                });
            }
            return genreDALs;
        }

        private static StudioDAL ConvertStudioToSudioDAL(Studio studio)
        {
            StudioDAL studioDAL = new StudioDAL
            {
                Name = studio.Name,
                Description = studio.Description
            };
            return studioDAL;
        }

        public static byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png); // сохраняем изображение в поток в формате PNG
                return ms.ToArray(); // возвращаем массив байтов
            }
        }

    }
}
