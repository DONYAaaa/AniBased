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
    internal class StudioRepository : IStudioRepository
    {
        private readonly string _connectionString;

        public StudioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAsync(StudioDAL studioDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL add_studio(@name, @description)", connection);
                command.Parameters.AddWithValue("@name", studioDAL.Name);
                command.Parameters.AddWithValue("@description", studioDAL.Description);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL delete_studio(@Id)", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<StudioDAL> GetByIdAsync(int id)
        {
            StudioDAL studioDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT * FROM studios WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        studioDAL = new StudioDAL();
                        studioDAL.Name = (string)reader["name"];
                        studioDAL.Description = (string)reader["description"];
                    }
                }
            }

            if (studioDAL == null)
            {
                throw new Exception("Не удалось найти студию по такому Id");
            }

            return studioDAL;
        }
    }
}
