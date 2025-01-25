using HardkorowyKodsu.Core.Interfaces;
using HardkorowyKodsu.Data.Strategies;

namespace HardkorowyKodsu.Data.Factories
{
    public class DatabaseStrategyFactory
    {
        public static IDatabaseStrategy CreateStrategy(string databaseType, string connectionString)
        {
            return databaseType.ToLower() switch
            {
                "mssql" => new MsSqlStrategy(connectionString),
                "postgresql" => new PostgreSqlStrategy(connectionString),
                _ => throw new NotSupportedException($"Database type '{databaseType}' is not supported.")
            };
        }
    }
}
