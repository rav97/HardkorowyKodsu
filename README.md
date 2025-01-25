# HardkorowyKodsu
Recruitment task for the position of .NET Developer for SERTUM Sp. z o.o.

## Functionality

### API
ASP.NET REST API with a connection to a database specified in a configuration file. Provides methods to display the database structure, tables, views and their column properties.

### Client
ASP.NET API with a connection to a database specified in a configuration file. Provides methods to display the database structure, tables, views, and column properties.

## Setup
In order to run the programs, you must prepare the appropriate configuration.

### API
API requires connection string to an SQL database. It can be PostgreSQL or MSSQL database engine.

Navigate to HardkorowyKodsu.API and open `appsettings.json` file. 
You need to specify `"DatabaseType"` if you're using PostgreSQL database you need to set value of this property to `"postgresql"`. 
If you're using MSSQL database you need to  set value of this property to `"mssql"`.

Next you need to set the connection string to database of your choice. To do so paste your connection string under value `"DefaultConnection"`

Your `appsettings.json` file should look like below:

```

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",

  "DatabaseType": "mssql", // Allowed Values: "mssql", "postgresql"
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=northwind;Integrated Security=true;"
  }
}

```

### Client
For the client application to work correctly, it is necessary to indicate the base url to the running instance of the API application using the `apiBaseUrl` environment variable.

The variable can be set in many ways, but the easiest way to do it is in Visual Studio. To do this, temporarily set the `HardkorowyKodsu.Client` project as the startup project. Then press the down arrow next to the compile button and select `HardkorowyKodsu.Client Debug Properties` from the drop-down menu. In the window that appears, go to the Environment variables section and set the value of the variable named `apiBaseUrl` to the base URL of your API. By default, for the https profile compilation, it should be `https://localhost:7210/api`

## Run the applications
In Visual Studio set both HardkorowyKodsu.Client and HardkorowyKodsu.API as startup project, make sure that API project starts before the Client app and press the start button.


## Important notes
- API was tested using PostgreSQL (v12 and v14.6) and MSSQL 2019 older/newer versions of database engine might require slight adjustments in the code.
- You can expand the app functionality by implementing your own DatabaseStrategy by implementing `IDatabaseStrategy` interface and adjusting `DatabaseStrategyFactory` to new configuration.