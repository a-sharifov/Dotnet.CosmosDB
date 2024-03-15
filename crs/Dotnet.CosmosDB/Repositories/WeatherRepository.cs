using Dotnet.CosmosDB.DbContexts;
using Dotnet.CosmosDB.DbContexts.Interfaces;
using Dotnet.CosmosDB.Models;
using Dotnet.CosmosDB.Repositories.Interfaces;

namespace Dotnet.CosmosDB.Repositories;

public class WeatherRepository(WeatherCosmosDBContext cosmosDBContext) 
    : EntityBaseRepository<Weather>(cosmosDBContext),  IWeatherRepository
{

}
