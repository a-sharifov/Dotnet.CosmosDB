using Newtonsoft.Json;

namespace Dotnet.CosmosDB.DbContexts.Interfaces;

public interface ICosmosEntity
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; }

    [JsonProperty(PropertyName = "partitionKey")]
    public string PartitionKey { get; }
}
