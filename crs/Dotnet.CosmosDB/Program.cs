using Dotnet.CosmosDB.DbContexts;
using Dotnet.CosmosDB.DbContexts.Extensions;
using Dotnet.CosmosDB.Models;
using Dotnet.CosmosDB.Repositories;
using Dotnet.CosmosDB.Repositories.Interfaces;
using Dotnet.CosmosDB.Services.Weathers;
using Dotnet.CosmosDB.Services.Weathers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddYamlFile("appsettings.yml", true, true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCosmosDBContext<WeatherCosmosDBContext>(x =>
{
    builder.Configuration.GetSection("CosmosDB").Bind(x);
});

builder.Services.AddTransient<IWeatherRepository, WeatherRepository>();
builder.Services.AddTransient<IWeatherService, WeatherService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.CreateDatabaseIfNotExists<WeatherCosmosDBContext>();

//TODO: Add more flexible method.
//Add reflection metod.
app.CreateContainerIfNotExists<WeatherCosmosDBContext, Weather>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
