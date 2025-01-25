using HardkorowyKodsu.Core.Interfaces;
using HardkorowyKodsu.Data.Factories;
using Microsoft.AspNetCore.Mvc;

namespace HardkorowyKodsu.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly ILogger<DatabaseController> _logger;
        private readonly IDatabaseStrategy _databaseStrategy;

        public DatabaseController(IConfiguration configuration, ILogger<DatabaseController> logger)
        {
            var databaseType = configuration["DatabaseType"];
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _databaseStrategy = DatabaseStrategyFactory.CreateStrategy(databaseType, connectionString);
            _logger = logger;
        }

        [HttpGet("tables")]
        public IActionResult GetTables()
        {
            var tables = _databaseStrategy.GetTables();
            _logger.LogInformation("Requsted table list - {0} tables returned", tables.Count);
            return Ok(tables);
        }

        [HttpGet("views")]
        public IActionResult GetViews()
        {
            var views = _databaseStrategy.GetViews();
            _logger.LogInformation("Requsted views list - {0} views returned", views.Count);
            return Ok(views);
        }

        [HttpGet("{tableName}/columns")]
        public IActionResult GetColumns(string tableName)
        {
            var columns = _databaseStrategy.GetColumns(tableName);
            _logger.LogInformation("Requested list of columns for table or view named \'{0}\' - returned {1} elements", tableName, columns.Count);
            return Ok(columns);
        }
    }
}
