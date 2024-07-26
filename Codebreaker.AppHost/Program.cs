var builder = DistributedApplication.CreateBuilder(args);

string dataStore = builder.Configuration["DataStore"] ?? "InMemory";

var sqlServer = builder.AddSqlServer("sql")
    .AddDatabase("CodebreakerSql", "codebreaker");

builder.AddProject<Projects.Codebreaker_GameAPIs>("gameapis")
    .WithEnvironment("DataStore", dataStore)
    .WithReference(sqlServer);

builder.Build().Run();
