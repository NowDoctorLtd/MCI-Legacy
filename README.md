MCI Platform
============

Sample ASP.Net searchable directory Web application. Will use SQLite for a database, EF for data access.

Not implemented: Sane separation of concerns like Services, or any sort of security. No registration or identity management either.

This is useful to learn basic ASP.Net concepts, play around and see what you can create... or break.

C# version.

## WHAT CAN I DO?
You can build it and search the database for practitioners matching your query. Try searching for Dr. Dre or Doolittle.

## REPO LAYOUT

```
mci_main/                      Root of solution
mci_main/Controllers           Controllers for various routes in the application
mci_main/Data                  All databases tables are defined here. 'MciContext' is the class used to access the DB.
mci_main/Models                DTOs and view models - used to pass data around the application.
mci_main/Repository            DAL or repository - used to access tables in the database.
mci_main/Views                 Razor (CSHTML) templates. Used by Controllers to render individual pages.
mci_main/wwwroot               WWWRoot. Contains JavaScript and CSS files used in the Razor templates.

mci_main/Program.cs            Main startup file. Launched by ASP.NET. Connects to DB, starts all services and injects repositories.
```

## Adding more to the DB

Add in extra data here:

```
mci_main/Data/SeedData.cs
```

Currently only "Practitioners" and "Specialties" may be added.

## Getting Started on Linux.

Install Dotnet:

https://learn.microsoft.com/en-gb/dotnet/core/install/linux-debian

Install Efcore:

```
dotnet tool install --global dotnet-ef
```

Update PATH:

```
PATH="$PATH:~/.dotnet/tools"
```

Update DB:

```
dotnet-ef database update && sqlite3 mci.db < insertspecs.sql
```

Run it:

```
$ dotnet run
```

