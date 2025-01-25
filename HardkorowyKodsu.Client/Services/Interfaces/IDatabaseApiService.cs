using HardkorowyKodsu.Core.Models;
using Refit;

namespace HardkorowyKodsu.Client.Services.Interfaces
{
    public interface IDatabaseApiService
    {
        [Get("/Database/tables")]
        Task<List<string>> GetTablesAsync();

        [Get("/Database/views")]
        Task<List<string>> GetViewsAsync();

        [Get("/Database/{tableName}/columns")]
        Task<List<ColumnInfo>> GetTableColumnsAsync(string tableName);
    }
}
