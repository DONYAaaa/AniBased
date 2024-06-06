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
            AnimeDAL animeDAL = new AnimeDAL();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM Animes WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (await reader.ReadAsync())
                    {
                        animeDAL.Id = (int)reader["Id"];
                        animeDAL.Name = (string)reader["Name"];
                        DateTime dateTime = (DateTime)reader["yearofrealise"];
                        animeDAL.ReleaseDate = new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
                        animeDAL.NumberOfEpisodes = (int)reader["numberofepisodes"];
                        animeDAL.Description = (string)reader["Description"];
                        animeDAL.LinkToView = (string)reader["linkofanime"];
                        animeDAL.AgeRestriction = (int)reader["agerestriction"];
                        animeDAL.Dubbing = (string)reader["dubbing"];
                    }
                }

                command = new NpgsqlCommand("SELECT * FROM get_genres_by_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@id_argument", id);

                using (var reader = command.ExecuteReader())
                {
                    animeDAL.Genres = new List<GenreDAL>();
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

                using (var reader = command.ExecuteReader())
                {
                    if (await reader.ReadAsync())
                    {
                        StudioDAL studio = new StudioDAL();
                        studio.Name = (string)reader["studioname"];
                        studio.Description = (string)reader["studiodescription"];
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

        public async Task<List<AnimeDAL>> GetAllAsync()
        {
            List<AnimeDAL> animes = new List<AnimeDAL>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM public.animes\r\nORDER BY id ASC ", connection);

                var reader = command.ExecuteReader();
                {
                    while (await reader.ReadAsync())
                    {
                        AnimeDAL animeDAL = new AnimeDAL();
                        animeDAL.Id = (int)reader["Id"];
                        animeDAL.Name = (string)reader["Name"];
                        DateTime dateTime = (DateTime)reader["yearofrealise"];
                        animeDAL.ReleaseDate = new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
                        animeDAL.NumberOfEpisodes = (int)reader["numberofepisodes"];
                        animeDAL.Description = (string)reader["Description"];
                        animeDAL.LinkToView = (string)reader["linkofanime"];
                        animeDAL.AgeRestriction = (int)reader["agerestriction"];
                        animeDAL.Dubbing = (string)reader["dubbing"];


                        animeDAL.Genres = GetGenreByAnimeId(animeDAL.Id);

                        animeDAL.Studio = GetStudioByAnimeId(animeDAL.Id);


                        animes.Add(animeDAL);
                    }
                }
            }
            
            return animes;
        }

        private List<GenreDAL> GetGenreByAnimeId(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM get_genres_by_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@id_argument", id);
                List<GenreDAL> Genres = new List<GenreDAL>();

                using (var readerInto = command.ExecuteReader())
                {
                    while (readerInto.Read())
                    {
                        GenreDAL genre = new GenreDAL();
                        genre.Name = (string)readerInto["name"];
                        genre.Description = (string)readerInto["description"];
                        Genres.Add(genre);
                    }
                }
            return Genres;
            }
        }

        private StudioDAL GetStudioByAnimeId(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM get_studio_by_anime_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@id_argument", id);
                StudioDAL studio = new StudioDAL();

                using (var readerInto = command.ExecuteReader())
                {
                    if (readerInto.Read())
                    {
                        studio.Name = (string)readerInto["studioname"];
                        studio.Description = (string)readerInto["studiodescription"];
                    }
                }

                return studio;
            }
        }
    }
}
