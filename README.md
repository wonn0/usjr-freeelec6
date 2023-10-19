# Connecting to DB

In order to connect to the database, follow these steps:

1. Open the search bar and search for "SQL". Open the SQL Server Object Explorer. This will open a new side window that displays the SQL Server.
2. Right-click the Databases folder under "SQL Server", then create a new database. Name this whatever you want.
3. Right-click the database you just made and click on "Properties". Locate the connection string and copy it.
4. Locate the `"DefaultConnection"` values found under `ASI.Basecode.WebApp/appsettings.json`, and replace its value with the connection string you copied in Step 3.

### IMPORTANT!
>If you're not able to use SQL Server Object Explorer, SSMS or SQL Workbench is fine, as long as you have the connection string to place in you appsettings.json file.

# Running Seeders

The seeding of data was done using T-SQL Queries executed in the SQL Server Object Explorer, done by running the seeders found in `ASI.Basecode.Data/Seeders`. If you're not using SQL Server Object Explorer, this can also be done through SQL Workbench or SSMS, depending on what you're using.

# Running Migrations

### IMPORTANT!
>Make sure these steps are accomplished before proceeding to migrations:

1. Right click solution file (Solution `'ASI.Bascode'`) and then select properties
2. Select Single startup project and select `ASI.Basecode.WebApp as startup project`
3. Open Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console)
4. In the Default project dropdown, select `ASI.Basecode.Data`
5. Right-click each project, open `"Manage NuGet Packages..."` and update all the packages required by the project.
6. Rebuild `ASI.Basecode.Data`.
7. Rebuild the solution.
8. Proceed with migration.
                
                                
---
                
                       
[ASP.NET Migrations Overview](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs)

Migrations need to be run when new tables are being made or old tables are either being updated or dropped. In this case the backend developer will inform the team that a migration has been made, which will be run on your end through this command on the NUGET Package Console `(Tools > NuGet Package Manager > Package Manager Console)`:

```
Update-Database
```

This updates your database to the latest migration.