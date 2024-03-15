using Dotnet.CosmosDB.DbContexts.Abstractions;
using Dotnet.CosmosDB.DbContexts.Options;
using Microsoft.Extensions.Options;

namespace Dotnet.CosmosDB.DbContexts;

public class WeatherCosmosDBContext(IOptions<CosmosDBContextOptions<WeatherCosmosDBContext>> options) : CosmosDBContext(options)
{

}
