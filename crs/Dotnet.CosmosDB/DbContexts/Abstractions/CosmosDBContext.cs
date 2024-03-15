using Dotnet.CosmosDB.DbContexts.Attributes;
using Dotnet.CosmosDB.DbContexts.Interfaces;
using Dotnet.CosmosDB.DbContexts.Options;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Dotnet.CosmosDB.DbContexts.Abstractions;

public abstract class CosmosDBContext : ICosmosDBContext, IDisposable
{
    private readonly CosmosDBContextOptions _options;
    private readonly CosmosClient _client;

    private bool _disposed;

    public CosmosDBContext(IOptions<CosmosDBContextOptions> options) 
    {
        _options = options.Value;
        _client = new(_options.Endpoint, _options.Key);
    }

    public Database GetDatabase() =>
        _client.GetDatabase(_options.DatabaseName);

    public async Task CreateDatabaseAsync() =>
        await _client.CreateDatabaseIfNotExistsAsync(_options.DatabaseName, 400);

    public async Task CreateContainerAsync(string containerName)
    {
        var database = GetDatabase(); 
        var container = new ContainerProperties(containerName, "/partitionKey");
        await database.CreateContainerIfNotExistsAsync(container);
    }

    public async Task CreateContainerAsync<TEntity>() where TEntity : ICosmosEntity
    {
        var containerName = GetContainerName<TEntity>();
        await CreateContainerAsync(containerName);
    }

    public string GetContainerName<TEntity>() where TEntity : ICosmosEntity
    {
        var entityType = typeof(TEntity);
        var attribute = entityType.GetCustomAttribute(typeof(BindToContainerAttribute));

        if (attribute is null)
        {
            return entityType.Name;
        }

        var bindToContainerAttribute = attribute as BindToContainerAttribute;

        return bindToContainerAttribute!.ContainerName;
    }

    public Container GetContainer(string containerName) =>
        _client.GetContainer(_options.DatabaseName, containerName);

    public Container GetContainer<TEntity>() where TEntity : ICosmosEntity
    {
        var containerName = GetContainerName<TEntity>();
        return GetContainer(containerName);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }
        _client?.Dispose();
        GC.SuppressFinalize(this);
        _disposed = true;
    }

    ~CosmosDBContext() => Dispose();
}
