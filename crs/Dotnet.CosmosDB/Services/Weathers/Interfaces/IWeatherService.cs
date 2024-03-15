using Dotnet.CosmosDB.Models;
using Dotnet.CosmosDB.Services.Weathers.Requests;

namespace Dotnet.CosmosDB.Services.Weathers.Interfaces;

public interface IWeatherService
{
    Task AddAsync(AddRequest request);
    Task Delete(string id);
    Weather Get(string id);
    Task<IEnumerable<Weather>> GetAllAsync();
    Task UpdateTemperatureCAsync(UpdateTemperatureCRequest request);
    Task UpdateSummaryAsync(UpdateSummaryRequest request);
}