# Services

This project was created using Visual Studio 2017 and SQL Server Express 2016 targeting .NET Core 2.2


Open PressfordConsulting.sln and restore packages.

## Databases

AspIdUsers SQLite databases is already seeded with 2 users and respective claims. Download SQLiteStudio [https://sqlitestudio.pl] to interrogate database if desired.

To install SQL Server database:
1. Go to Package Manager console 
2. Set the default project to News.Infrastructure
3. The default connection string is set to LocalDB. To change update News.API appsettigns.json and in News.Infrastructure NewsContext.cs.
4. Run 'Update-Database' to apply migrations
5. Confirm that a database called PressfordConsulting has been created
6. Run SeedData.sql against database


## Run

Set the project up to run Multiple startup projects:
1. In Visual Studio, right-click Solution > Multiple startup projects
2. Set Identity.API and News.API project action to 'Start'
3. Launch the debugger
4. IdentityServer4 should launch in new browser window on http://localhost:5000/, the Angular Client has a dependency on this port being used.
5. Swagger should launch in a new browser version on https://localhost:44305/swagger-ui/index.html. the Angular Client has a dependency on this port being used. SSL is enabled for News.API, accept any Visual Studio prompts to install certificate).

