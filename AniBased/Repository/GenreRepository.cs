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
    internal class GenreRepository : IGenreRepository
    {
        private readonly string _connectionString;

        public GenreRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAsync(GenreDAL genreDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL add_genre(@name, @description)", connection);
                command.Parameters.AddWithValue("@name", genreDAL.Name);
                command.Parameters.AddWithValue("@description", genreDAL.Description);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL delete_genre(@Id)", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<GenreDAL> GetByIdAsync(int id)
        {
            GenreDAL genreDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT * FROM studios WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        genreDAL = new GenreDAL();
                        genreDAL.Name = (string)reader["name"];
                        genreDAL.Description = (string)reader["description"];
                    }
                }
            }

            if (genreDAL == null)
            {
                throw new Exception("Не удалось найти студию по такому Id");
            }

            return genreDAL;
        }
    }
}
