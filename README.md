# SisVenda

## What is this project?
SisVenda is a simple sales software made with .Net Core at Backend with .Net Blazor and .NetMvc at Frontend. The current database used is MSSQL and the ORM is Entity Framework Core.

### EntityFramework - Migrations
[Entity framework](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli) is an ORM by [Microsoft](https://www.microsoft.com/) and makes queries to the database easier! 

This commands bellow shows to you the EF sintax 
```bash
# Creating a new migration
dotnet ef migrations add "Initial"
# Removing a existing migrations
dotnet ef migrations remove
# Updating a database with migrations
dotnet ef database update
```

Currently all migrations are made at SisVenda.Infra to share all DB migrations with the backend api and MVC. To run a new command you should go to the Server or UIMVC project and reference Infra project like the next sample.
```bash
dotnet ef migrations add Initial --project ..\SisVenda.Infra\ 
```

### EF Core Documentation 
Two recommendations to learn EF core is his own site [Entity framework](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli) and [Learn Entity Framework Core](https://www.learnentityframeworkcore.com/).