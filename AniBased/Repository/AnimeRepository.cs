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
                var command = new NpgsqlCommand("INSERT INTO Installation (StartDate, IdOrganization) " +
                                                "VALUES (@StartDate, @IdOrganization)", connection);
                command.Parameters.AddWithValue("@StartDate", installationDAL.Date);
                command.Parameters.AddWithValue("@IdOrganization", installationDAL.IdOrganization);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AnimeDAL GetByid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
