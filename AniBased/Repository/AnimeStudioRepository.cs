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
    internal class AnimeStudioRepository : IAnimeStudioRepository
    {
        private readonly string _connectionString;

        public AnimeStudioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAsync(AnimeDAL animeDAL, StudioDAL studioDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL add_anime_studio(@idanime_argument, @idstudio_argument)", connection);
                command.Parameters.AddWithValue("@idanime_argument", animeDAL.Id);
                command.Parameters.AddWithValue("@idstudio_argument", studioDAL.Id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL delete_anime_studio_by_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
