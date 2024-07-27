# codebreaker-aspire

Using `dotnet ef migrations` fails referencing the games API startup project because the EF Core configuration is now in `ApplicationServices` instead of the `Program.cs`, and thus cannot be found from the `dotnet ef` tool.

See the different options to create the context at design time: [Design-time DbContext Creation](https://learn.microsoft.com/en-us/ef/core/cli/dbcontext-creation)

I added the `GamesSqlServerContextFactory` class to the SQL Server library which can be used this way to create a new migration:

```bash
cd Codebreaker.Data.SqlServer
dotnet ef migrations add <Name> -- "server=(localdb)\mssqllocaldb;database=Test;trusted_connection=true"
```

A connection string to the database needs to be passed following `--` which is read with arguments from the `GamesSqlServerContextFactory`.
