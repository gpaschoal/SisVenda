# SisVenda

## What is this project?
SisVenda is a simple sales software made with dotnet Core at Backend with dotnet Blazor and dotnet Mvc at Frontend. The current database used is MSSQL and the ORM is Entity Framework Core.

### EntityFramework - Migrations
[Entity Framework](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli) is an ORM by [Microsoft](https://www.microsoft.com/) and makes queries to the database easier! 

This commands below shows to you the EF syntax 
```bash
# New migrations
dotnet ef migrations add "Initial"
# Removing migrations
dotnet ef migrations remove
# Updating database
dotnet ef database update
```

Currently, all migrations are made at SisVenda.Infra to share all DB migrations with the backend API and MVC. To run a new command you should go to the Server or UIMVC project and reference the Infra project like the next sample.
```bash
dotnet ef migrations add Initial --project ..\SisVenda.Infra\ 
```

### EF Core Documentation 
Two recommendations to learn EF core is his own site [Entity Framework](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli) and [Learn Entity Framework Core](https://www.learnentityFrameworkcore.com/).