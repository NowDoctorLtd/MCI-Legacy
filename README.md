MCI Platform
============

Sample ASP.Net searchable directory Web application. Will use SQLite for a database, EF for data access.

Not implemented: Sane separation of concerns like Services, or any sort of security. No registration or identity management either.

This is useful to learn basic ASP.Net concepts, play around and see what you can create... or break.

C# version.

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

