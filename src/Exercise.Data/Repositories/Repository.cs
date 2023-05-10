using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace Exercise.Data.Repositories
{
    public class Repository
    {
        private readonly string _connectionString;

        public Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Exercise");
        }

        protected DataRow Get(TableProperties table, int id)
        {
            string query = $"SELECT * FROM {table.Name} WHERE {table.IdColumnName} = {id}";
            DataSet dataSet = ExecuteQuery(table, query);
            DataRowCollection rows = dataSet.Tables[0].Rows;
            if (rows.Count == 1) return rows[0];
            else return null;
        }

        protected DataSet GetAll(TableProperties table)
        {
            string query = $"SELECT * FROM {table.Name}";
            return ExecuteQuery(table, query);
        }

        protected DataSet GetMany (TableProperties table, int size, int offset)
        {
            string query = $"SELECT * FROM {table.Name} LIMIT {size} OFFSET {offset}";
            return ExecuteQuery(table, query);
        }

        protected DataSet ExecuteQuery (TableProperties table, string query)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                DataSet dataSet = new DataSet();

                connection.OpenAsync();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    var adapter = new NpgsqlDataAdapter(command);
                    adapter.Fill(dataSet, table.Name);
                }

                return dataSet;
            }
        }

        protected int ExecuteNonQuery (string query)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.OpenAsync();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        protected class TableProperties
        {
            public string Name { get; set; }
            public string IdColumnName { get; set; }
        }

    }
}
