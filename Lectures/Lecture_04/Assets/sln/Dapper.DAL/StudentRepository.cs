using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Dapper.DAL.Entities;
using Microsoft.Extensions.Configuration;

namespace Dapper.DAL
{
    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository()
        {
            _connectionString = GetConnectionString();
        }

        public IEnumerable<StudentEntity> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var statement = "SELECT * FROM Students";
                connection.Open();

                var result = connection.Query<StudentEntity>(statement);
                return result.ToList();
            }
        }

        public StudentEntity GetById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var statement = "SELECT * FROM Students WHERE Id = @Id";
                connection.Open();

                var result = connection.Query<StudentEntity>(statement, new {Id = id});
                return result.FirstOrDefault();
            }
        }

        public void Insert(StudentEntity entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var statement = "INSERT INTO Students (Id, Name) Values (@Id, @Name);";
                connection.Open();

                connection.Execute(statement, new {entity.Id, entity.Name});
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var statement = "DELETE FROM Students WHERE Id = @Id;";
                connection.Open();

                connection.Execute(statement, new {Id = id});
            }
        }

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appconfig.json");

            var configuration = builder.Build();
            return configuration.GetConnectionString("SchoolContext");
        }
    }
}