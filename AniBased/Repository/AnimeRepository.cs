using AniBased.DAL;
using AniBased.Repository.Interface;
using DocumentFormat.OpenXml.Office2010.Excel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Repository
{
    internal class AnimeRepository : IAnimeRepository
    {
        private readonly string _connectionString;

        public AnimeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAsync(AnimeDAL animeDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL add_anime(Id, Name, yearofrealise, numberofepisodes, description, linkofanime, agerestriction, dubbing, poster) ", connection);
                command.Parameters.AddWithValue("@Id", animeDAL.Id);
                command.Parameters.AddWithValue("@Name", animeDAL.Name);
                command.Parameters.AddWithValue("@yearofrealise", animeDAL.ReleaseDate);
                command.Parameters.AddWithValue("@numberofepisodes", animeDAL.NumberOfEpisodes);
                command.Parameters.AddWithValue("@description", animeDAL.Description);
                command.Parameters.AddWithValue("@linkofanime", animeDAL.LinkToView);
                command.Parameters.AddWithValue("@agerestriction", animeDAL.AgeRestriction);
                command.Parameters.AddWithValue("@dubbing", animeDAL.Dubbing);
                command.Parameters.AddWithValue("@poster", animeDAL.Poster);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL delete_anime(@Id)", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<AnimeDAL> GetByIdAsync(int id)
        {
            AnimeDAL animeDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT * FROM Animes WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        animeDAL.Id = (int)reader["Id"];
                        animeDAL.Name = (string)reader["Name"];
                        animeDAL.ReleaseDate = (DateOnly)reader["yearofrealese"];
                        animeDAL.NumberOfEpisodes = (int)reader["numberofepisodes"];
                        animeDAL.Description = (string)reader["Description"];
                        animeDAL.LinkToView = (string)reader["linkofanime"];
                        animeDAL.AgeRestriction = (int)reader["agerestriction"];
                        animeDAL.Dubbing = (string)reader["dubbing"];
                        animeDAL.Poster = (byte[])reader["poster"];
                    }
                }

                command = new NpgsqlCommand("SELECT * FROM get_genres_by_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@id_argument", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        GenreDAL genre = new GenreDAL();
                        genre.Name = (string)reader["name"];
                        genre.Description = (string)reader["description"];
                        animeDAL.Genres.Add(genre);
                    }
                }

                command = new NpgsqlCommand("SELECT * FROM get_studio_by_anime_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@id_argument", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        StudioDAL studio = new StudioDAL();
                        studio.Name = (string)reader["name"];
                        studio.Description = (string)reader["description"];
                        animeDAL.Studio = studio;
                    }
                }
            }

            if (animeDAL == null)
            {
                throw new Exception("Не нашлось аниме по такому Id");
            }

            return animeDAL;
        }
    }
}
