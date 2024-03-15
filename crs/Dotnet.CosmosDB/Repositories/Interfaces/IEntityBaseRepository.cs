using Dotnet.CosmosDB.Models;
using Dotnet.CosmosDB.Models.Common.Interfaces;

namespace Dotnet.CosmosDB.Repositories.Interfaces;

public interface IEntityBaseRepository<TEnity> where TEnity : IEntity
{
    Task AddAsync(Weather weather);
    Task DeleteByIdAsync(string id);
    Task<IEnumerable<TEnity>> GetAllAsync();
    TEnity GetFirst(Func<TEnity, bool> func);
    TEnity GetById(string id);
    TEnity? GetFirstOrDefault(Func<TEnity, bool> func);
    Task UpdateAsync(Weather weather);
}