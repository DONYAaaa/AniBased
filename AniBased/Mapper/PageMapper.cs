using AniBased.DAL;
using AniBased.Model.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Mapper
{
    internal static class PageMapper
    {
        public static PageOfAnime ToBLL(this PageOfAnimeDAL entity)
        {
            return new PageOfAnime(entity.Id, entity.Name, ConvertListAnimeDalToAnime(entity.AnimeDAL));
        }

        private static List<Anime> ConvertListAnimeDalToAnime(List<AnimeDAL> animeList) 
        {
            List<Anime> newList = new List<Anime>();

            foreach (var item in animeList)
            {
                newList.Add(AnimeMapper.ToBLL(item));
            }

            return newList;
        }

        public static PageOfAnimeDAL ToDAL(this PageOfAnime entity)
        {
            return new PageOfAnimeDAL
            {
                Id = entity.Id,
                Name = entity.Name,
                AnimeDAL = ConvertListAnimeToAnimeDAL(entity.Animes)
            };
        }

        private static List<AnimeDAL> ConvertListAnimeToAnimeDAL(List<Anime> animeList)
        {
            List<AnimeDAL> newList = new List<AnimeDAL>();

            foreach (var item in animeList)
            {
                newList.Add(AnimeMapper.ToDAL(item));
            }

            return newList;
        }
    }
}
