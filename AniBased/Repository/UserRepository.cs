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
    internal class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAsync(UserDAL userDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL add_user(@Id, @Nickname, @password_hash, @dateOfBirth, @mail)", connection);
                command.Parameters.AddWithValue("@Id", userDAL.Id);
                command.Parameters.AddWithValue("@Nickname", userDAL.Nickname);
                command.Parameters.AddWithValue("@password_hash", userDAL.PasswordHash);
                command.Parameters.AddWithValue("@dateOfBirth", userDAL.DateOfBirth);
                command.Parameters.AddWithValue("@mail", userDAL.Mail);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL delete_user_by_id(@Id)", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<UserDAL> GetByIdAsync(int id)
        {
            UserDAL userDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT * FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        userDAL = new UserDAL();
                        userDAL.Id = (int)reader["Id"];
                        userDAL.Nickname = (string)reader["Nickname"];
                        userDAL.PasswordHash = (string)reader["password_hash"];
                        userDAL.DateOfBirth = (DateOnly)reader["dateOfBirth"];
                        userDAL.Mail = (string)reader["mail"];
                    }
                }
            }

            if (userDAL == null)
            {
                throw new Exception("Не удалось найти пользователя по такому Id");
            }

            return userDAL;
        }
    }
}
