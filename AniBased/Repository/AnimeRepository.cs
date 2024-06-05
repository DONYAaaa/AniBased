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

        public void Add(AnimeDAL animeDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO Animes (Id, Name, yearofrealise, description, linkofanime, agerestriction, dubbing, poster) " +
                                                "VALUES (@StartDate, @IdOrganization)", connection);
                command.Parameters.AddWithValue("@Id", animeDAL.Id);
                command.Parameters.AddWithValue("@Name", animeDAL.Name);
                command.Parameters.AddWithValue("@yearofrealise", animeDAL.ReleaseDate);
                command.Parameters.AddWithValue("@description", animeDAL.Description);
                command.Parameters.AddWithValue("@linkofanime", animeDAL.LinkToView);
                command.Parameters.AddWithValue("@agerestriction", animeDAL.AgeRestriction);
                command.Parameters.AddWithValue("@dubbing", animeDAL.Dubbing);
                command.Parameters.AddWithValue("@poster", animeDAL.Poster);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString)) //TODO Как быть с каскадным удалением
            {
                connection.Open();
                var command = new NpgsqlCommand("DELETE FROM Animes WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public AnimeDAL GetByid(int id)
        {
            AnimeDAL animeDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString)) //TODO как быть с жанрами и студиями
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM Animes WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
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
            }

            if (animeDAL == null)
            {
                throw new Exception("Не нашлось аниме по такому Id");
            }

            return animeDAL;
        }
    }
}
