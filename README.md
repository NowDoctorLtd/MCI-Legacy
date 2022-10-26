MCI Platform
============

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

