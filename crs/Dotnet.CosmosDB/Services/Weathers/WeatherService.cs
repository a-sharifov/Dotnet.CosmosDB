using Dotnet.CosmosDB.Models;
using Dotnet.CosmosDB.Repositories.Interfaces;
using Dotnet.CosmosDB.Services.Weathers.Interfaces;
using Dotnet.CosmosDB.Services.Weathers.Requests;

namespace Dotnet.CosmosDB.Services.Weathers;

public class WeatherService(ILogger<WeatherService> logger, IWeatherRepository repository) : IWeatherService
{
    private readonly ILogger<WeatherService> _logger = logger;
    public readonly IWeatherRepository _repository = repository;

    public async Task<IEnumerable<Weather>> GetAllAsync()
    {
        var weathers = await _repository.GetAllAsync();
        _logger.LogInformation("Retrieved {Count} weather entries from the repository.", weathers.Count());
        return weathers;
    }

    public Weather Get(string id)
    {
        try
        {
            var weather = _repository.GetById(id);
            _logger.LogInformation("Retrieved weather entry with ID {Id} from the repository.", id);
            return weather;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving weather entry with ID {Id} from the repository.", id);
            throw;
        }
    }

    public async Task AddAsync(AddRequest request)
    {
        try
        {
            var weather = new Weather(request.Date, request.TemperatureC, request.Summary);
            await _repository.AddAsync(weather);
            _logger.LogInformation("Added new weather entry with Date to the repository.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding a new weather entry to the repository.");
            throw;
        }
    }

    public async Task Delete(string id)
    {
        try
        {
            await _repository.DeleteByIdAsync(id);
            _logger.LogInformation("Deleted weather entry with ID {Id} from the repository.", id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting weather entry with ID {Id} from the repository.", id);
            throw;
        }
    }

    public async Task UpdateTemperatureCAsync(UpdateTemperatureCRequest request)
    {
        try
        {
            var weather = _repository.GetById(request.Id);
            weather.UpdateTemperatureC(request.TemperatureC);
            await _repository.UpdateAsync(weather);
            _logger.LogInformation("Updated temperature for weather entry with ID {Id} to {TemperatureC} °C.", request.Id, request.TemperatureC);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating temperature for weather entry with ID {Id}.", request.Id);
            throw;
        }
    }

    public async Task UpdateSummaryAsync(UpdateSummaryRequest request)
    {
        try
        {
            var weather = _repository.GetById(request.Id);
            weather.UpdateSummary(request.Summary);
            await _repository.UpdateAsync(weather);
            _logger.LogInformation("Updated summary for weather entry with ID {Id}. New summary: {Summary}", request.Id, request.Summary);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating summary for weather entry with ID {Id}.", request.Id);
            throw;
        }
    }

}
