using HardkorowyKodsu.Core.Models;

namespace HardkorowyKodsu.Core.Interfaces
{
    public interface IDatabaseStrategy
    {
        public List<string> GetTables();
        public List<string> GetViews();
        public List<ColumnInfo> GetColumns(string tableName);
    }
}
