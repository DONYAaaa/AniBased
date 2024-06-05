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
                                .Build(); //TODO что делать с жанрами и студиями и в обратную
        }

        private static Image ConvertBytesArrayToImage(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
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
                Poster = ConvertImageToByteArray(entity.Image)
            };
        }

        public static byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // сохраняем изображение в поток в формате PNG
                return ms.ToArray(); // возвращаем массив байтов
            }
        }

    }
}
