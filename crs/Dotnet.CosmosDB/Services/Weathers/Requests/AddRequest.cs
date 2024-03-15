namespace Dotnet.CosmosDB.Services.Weathers.Requests;

public sealed record AddRequest(DateOnly Date, int TemperatureC, string Summary);
