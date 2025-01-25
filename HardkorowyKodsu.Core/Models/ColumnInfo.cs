namespace HardkorowyKodsu.Core.Models
{
    public class ColumnInfo
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public int? CharacterMaximumLength { get; set; }
        public bool IsNullable { get; set; }
    }
}
