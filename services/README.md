# Services

This project was created using Visual Studio 2017 and SQL Server Express 2016 targeting .NET Core 2.2


Open PressfordConsulting.sln and restore packages.

## Databases

AspIdUsers SQLite databases is already seeded with 2 users and respective claims. Download SQLiteStudio [https://sqlitestudio.pl] to interrogate database.

To install SQL Server database:
1. Go to Package Manager console 
2. Set the default project to News.Infrastructure
3. The default connection string is set to LocalDB. To change update News.API appsettigns.json and in News.Infrastructure NewsContext.cs.
4. Run 'Update-Database' to apply migrations
5. Confirm that a database called PressfordConsulting has been created
6. Run SeedData.sql against database


## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. 

IdentityServer4 and the API are configured to use this port for CORS and redirect.
