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
    internal class PageRepository : IUserRepository
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

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT * FROM pageofAnime WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        pageOfAnimeDAL = new PageOfAnimeDAL();
                        pageOfAnimeDAL.Id = (int)reader["Id"];
                        pageOfAnimeDAL.Name = (string)reader["name"];
                    }
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
