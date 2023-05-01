using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Exercise.Data.Models;
using System.Data;

namespace Exercise.Data.Repositories
{
    public class Repository
    {
        private readonly string _connectionString;

        public Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Exercise");
        }

        protected async Task<DataSet> GetMany (string tableName, int size, int offset)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM {tableName} LIMIT {size} OFFSET {offset}";
                DataSet dataSet = new DataSet();

                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    var adapter = new NpgsqlDataAdapter(command);
                    await Task.Run(() => adapter.Fill(dataSet, tableName));
                }

                return dataSet;
            }
        }

        protected async Task<int> ExecuteNonQuery (string query)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    return await Task.Run(() => command.ExecuteNonQuery());
                }
            }
        }

    }
}
