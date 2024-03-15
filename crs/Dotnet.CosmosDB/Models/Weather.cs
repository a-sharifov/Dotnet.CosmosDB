using Dotnet.CosmosDB.DbContexts.Attributes;
using Dotnet.CosmosDB.Models.Common.Interfaces;

namespace Dotnet.CosmosDB.Models;

[BindToContainer("WeatherForecast")]
public class Weather : IEntity
{
    public string Id { get; private set; } 

    public string PartitionKey { get; private set; }

    public DateOnly Date { get; private set; } 

    public int TemperatureC { get; private set; } 

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string Summary { get; private set; } 


    public Weather(DateOnly date, int temperatureC, string summary)
    {
        Id = Guid.NewGuid().ToString();
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
        PartitionKey = summary;
    }

    public void UpdateTemperatureC(int temperatureC) => TemperatureC = temperatureC;

    public void UpdateSummary(string summary) => Summary = summary;
}
