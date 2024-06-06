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

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {

                    connection.Open();
                    var command = new NpgsqlCommand("CALL add_genre(@name_argument, @description_argument)", connection);
                    command.Parameters.AddWithValue("@name_argument", genreDAL.Name);
                    command.Parameters.AddWithValue("@description_argument", genreDAL.Description);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
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
                        genreDAL.Id = (int)reader["id"];
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
