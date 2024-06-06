using AniBased.DAL;
using AniBased.Mapper;
using AniBased.Model.BLL.Entities;
using AniBased.Repository.Interface;
using DocumentFormat.OpenXml.Office2010.Excel;
using Npgsql;
using NpgsqlTypes;
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

        public async Task<UserDAL> GetByNameAsync(string name)
        {
            try
            {
                UserDAL userDAL = null;
                IPageRepository pageRepository = new PageRepository(_connectionString);

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new NpgsqlCommand("SELECT * FROM Users WHERE Nickname = @name", connection);
                    if (name == null)
                    {
                        command.Parameters.AddWithValue("@name", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@name", name);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        if (await reader.ReadAsync())
                        {
                            userDAL = new UserDAL();
                            userDAL.Id = (int)reader["Id"];
                            userDAL.Nickname = (string)reader["Nickname"];
                            userDAL.PasswordHash = (string)reader["password_hash"];
                            DateTime dateTime = (DateTime)reader["dateOfBirth"];
                            userDAL.DateOfBirth = new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day); 
                            userDAL.Mail = (string)reader["mail"];
                        }
                    }

                    command = new NpgsqlCommand("SELECT * FROM get_pages_by_id(@id_argument)", connection);
                    command.Parameters.AddWithValue("@id_argument", userDAL.Id);

                    using (var reader = command.ExecuteReader())
                    {
                        Library library = new();
                        while (await reader.ReadAsync())
                        {
                            int IdOfPages = (int)reader["Id"];
                            PageOfAnimeDAL page = await pageRepository.GetByIdAsync(IdOfPages);
                            PageOfAnime pageBLL = page.ToBLL();
                            library.Anime.Add(pageBLL);
                        }
                        userDAL.Library = library;
                    }
                }

                if (userDAL == null)
                {
                    return userDAL;
                }

                return userDAL;
            }

            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

        }
    }
}
