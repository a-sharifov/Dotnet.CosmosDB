namespace Dotnet.CosmosDB.Controllers.WeathersControllers.Requests;

public sealed record PutTemperatureCRequest(
    string Id,
    int TemperatureC
    );
