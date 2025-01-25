using HardkorowyKodsu.Core.Interfaces;
using HardkorowyKodsu.Core.Models;
using Microsoft.Data.SqlClient;

namespace HardkorowyKodsu.Data.Strategies
{
    public class MsSqlStrategy : IDatabaseStrategy
    {
        private readonly string _connectionString;

        public MsSqlStrategy(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<string> GetTables()
        {
            var tables = new List<string>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", connection);
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
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS", connection);
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
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName", connection);
                command.Parameters.AddWithValue("@TableName", tableName);
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
