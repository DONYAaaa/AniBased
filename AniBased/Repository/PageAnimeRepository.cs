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
    internal class PageAnimeRepository : IPageAnimeRepository
    {
        private readonly string _connectionString;

        public PageAnimeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAsync(PageOfAnimeDAL pageDAL, AnimeDAL animeDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL add_page_anime(@idpage_argument, @idanime_argument)", connection);
                command.Parameters.AddWithValue("@idpage_argument", pageDAL.Id);
                command.Parameters.AddWithValue("@idanime_argument", animeDAL.Id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL delete_page_anime_by_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
