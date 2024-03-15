using Dotnet.CosmosDB.DbContexts.Interfaces;

namespace Dotnet.CosmosDB.DbContexts.Options;

public class CosmosDBContextOptions<TContext> :
    CosmosDBContextOptions
    where TContext : ICosmosDBContext
{

}
