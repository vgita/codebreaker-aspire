var builder = DistributedApplication.CreateBuilder(args);

string dataStore = builder.Configuration["DataStore"] ?? "InMemory";

var gameApis = builder.AddProject<Projects.Codebreaker_GameAPIs>("gameapis")
    .WithExternalHttpEndpoints()
    .WithEnvironment("DataStore", dataStore);

if (dataStore == "SqlServer")
{
    var sqlPassword = builder.AddParameter("sql-password", secret: true);

    var sqlServer = builder.AddSqlServer("sql", sqlPassword)
        .AddDatabase("CodebreakerSql", "codebreaker");

    gameApis
        .WithReference(sqlServer);
}
else if (dataStore == "Cosmos")
{
    var cosmos = builder.AddAzureCosmosDB("codebreakercosmos")
       .AddDatabase("codebreaker");

    gameApis
        .WithReference(cosmos);
}

builder.Build().Run();
