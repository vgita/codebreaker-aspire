using Codebreaker.GameAPIs.Endpoints;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v3", new OpenApiInfo
    {
        Version = "v3",
        Title = "Codebreaker Games API",
        Description = "An ASP.NET Core minimal API to play Codebreaker games",
        TermsOfService = new Uri("https://picsum.photos/200/300?random=2"),
        Contact = new OpenApiContact
        {
            Name = "Contact",
            Url = new Uri("https://picsum.photos/200/300?random=2")
        },
        License = new OpenApiLicense
        {
            Name = "License API Usage",
            Url = new Uri("https://picsum.photos/200/300?random=2")
        }
    });
});

builder.Services.AddSingleton<IGamesRepository, GamesMemoryRepository>();
builder.Services.AddScoped<IGamesService, GamesService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    // options.InjectStylesheet("/swagger-ui/swaggerstyle.css");
    options.SwaggerEndpoint("/swagger/v3/swagger.json", "v3");
});


app.MapGameEndpoints();
app.Run();