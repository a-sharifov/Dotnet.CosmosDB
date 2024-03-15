using Dotnet.CosmosDB.DbContexts;
using Dotnet.CosmosDB.Models;
using Dotnet.CosmosDB.Models.Common.Interfaces;
using Dotnet.CosmosDB.Repositories.Interfaces;
using Microsoft.Azure.Cosmos;

namespace Dotnet.CosmosDB.Repositories;

public class EntityBaseRepository<TEnity> : IEntityBaseRepository<TEnity> where TEnity : IEntity
{
    protected readonly WeatherCosmosDBContext _cosmosDBContext;
    protected readonly Container _entityContainer;

    public EntityBaseRepository(WeatherCosmosDBContext cosmosDBContext)
    {
        _cosmosDBContext = cosmosDBContext;
        _entityContainer = _cosmosDBContext.GetContainer<TEnity>();
    }

    public async Task<IEnumerable<TEnity>> GetAllAsync()
    {
        var iterator = _entityContainer.GetItemQueryIterator<TEnity>();
        var weathers = new List<TEnity>();
        while (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync();
            weathers.AddRange(response.ToList());
        }
        return weathers;
    }

    public TEnity GetFirst(Func<TEnity, bool> func)
    {
        var orderedQueryable = _entityContainer.GetItemLinqQueryable<TEnity>(allowSynchronousQueryExecution: true);
        var entity = orderedQueryable.Where(func).FirstOrDefault();
        return entity!;
    }

    public TEnity GetById(string id) => GetFirst(x => x.Id == id);

    public TEnity? GetFirstOrDefault(Func<TEnity, bool> func)
    {
        var orderedQueryable = _entityContainer.GetItemLinqQueryable<TEnity>();
        var entity = orderedQueryable.Where(func).FirstOrDefault();
        return entity;
    }

    public async Task AddAsync(Weather weather) =>
        await _entityContainer.CreateItemAsync(weather);

    public async Task UpdateAsync(Weather weather) =>
        await _entityContainer.UpsertItemAsync(weather);

    public async Task DeleteByIdAsync(string id)
    {
        var weather = GetById(id);
        var partitionKey = new PartitionKey(weather.PartitionKey);
        await _entityContainer.DeleteItemAsync<TEnity>(weather.Id, partitionKey);
    }
}
