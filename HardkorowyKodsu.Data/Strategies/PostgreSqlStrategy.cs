using HardkorowyKodsu.Core.Interfaces;
using HardkorowyKodsu.Core.Models;
using Npgsql;

namespace HardkorowyKodsu.Data.Strategies
{
    public class PostgreSqlStrategy : IDatabaseStrategy
    {
        private readonly string _connectionString;

        public PostgreSqlStrategy(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<string> GetTables()
        {
            var tables = new List<string>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT table_name FROM information_schema.tables WHERE table_schema = 'public'", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tables.Add(reader.GetString(0));
                    }
                }
            }
            return tables;
        }

        public List<string> GetViews()
        {
            var views = new List<string>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT table_name FROM information_schema.views WHERE table_schema = 'public'", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        views.Add(reader.GetString(0));
                    }
                }
            }
            return views;
        }

        public List<ColumnInfo> GetColumns(string tableName)
        {
            var columns = new List<ColumnInfo>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand($"SELECT column_name, data_type, is_nullable, character_maximum_length FROM information_schema.columns WHERE table_name = '{tableName}'", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columns.Add(new ColumnInfo
                        {
                            ColumnName = reader.GetString(0),
                            DataType = reader.GetString(1),
                            IsNullable = reader.GetString(2) == "YES",
                            CharacterMaximumLength = reader.IsDBNull(3) ? null : reader.GetInt32(3)
                        });
                    }
                }
            }
            return columns;
        }
    }
}
