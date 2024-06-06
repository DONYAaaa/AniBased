using AniBased.DAL;
using AniBased.Repository.Interface;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Repository
{
    internal class PageRepository : IPageRepository
    {
        private readonly string _connectionString;

        public PageRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task AddAsync(PageOfAnimeDAL pageOfAnimeDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL add_page(@Id, @name)", connection);
                command.Parameters.AddWithValue("@Id", pageOfAnimeDAL.Id);
                command.Parameters.AddWithValue("@name", pageOfAnimeDAL.Name);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL delete_page_by_id(@Id)", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<PageOfAnimeDAL> GetByIdAsync(int id)
        {
            PageOfAnimeDAL pageOfAnimeDAL = null;
            IAnimeRepository animeRepository = new AnimeRepository(_connectionString);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM pageofAnime WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (await reader.ReadAsync())
                    {
                        pageOfAnimeDAL = new PageOfAnimeDAL();
                        pageOfAnimeDAL.Id = (int)reader["Id"];
                        pageOfAnimeDAL.Name = (string)reader["name"];
                    }
                }

                command = new NpgsqlCommand("SELECT * FROM get_animes_by_page_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@id_argument", id);

                using (var reader = command.ExecuteReader())
                {
                    List<AnimeDAL> animeDALs = new List<AnimeDAL>();
                    while (await reader.ReadAsync())
                    {
                        int IdOfAnime = (int)reader["Id"];
                        AnimeDAL anime = await animeRepository.GetByIdAsync(IdOfAnime);
                        animeDALs.Add(anime);
                    }
                    pageOfAnimeDAL.AnimeDAL = animeDALs; 
                }
            }

            if (pageOfAnimeDAL == null)
            {
                throw new Exception("Не удалось найти страничку по такому Id");
            }

            return pageOfAnimeDAL;
        }
    }
}
