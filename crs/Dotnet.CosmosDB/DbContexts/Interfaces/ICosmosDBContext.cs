using Microsoft.Azure.Cosmos;

namespace Dotnet.CosmosDB.DbContexts.Interfaces;

public interface ICosmosDBContext
{
    Container GetContainer(string containerName);
    Container GetContainer<TEntity>() where TEntity : ICosmosEntity;
    Database GetDatabase();
    string GetContainerName<TEntity>() where TEntity : ICosmosEntity;
    Task CreateContainerAsync(string containerName);
    Task CreateContainerAsync<TEntity>() where TEntity : ICosmosEntity;
    Task CreateDatabaseAsync();
}