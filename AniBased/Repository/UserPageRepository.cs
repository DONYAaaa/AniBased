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
    internal class UserPageRepository : IUserPageRepository
    {
        private readonly string _connectionString;

        public UserPageRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAsync(UserDAL userDAL, PageOfAnimeDAL pageDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL add_user_page(@iduser_argument, @idpage_argument)", connection);
                command.Parameters.AddWithValue("@iduser_argument", userDAL.Id);
                command.Parameters.AddWithValue("@idpage_argument", pageDAL.Id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL delete_user_page_by_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
