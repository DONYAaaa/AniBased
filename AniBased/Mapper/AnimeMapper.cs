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
                                .AddReleaseDate(entity.ReleaseDate.Year)
                                .Build(); //TODO что делать с жанрами и студиями и в обратную
        }

        private static Image ConvertBytesArrayToImage(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

    }
}
