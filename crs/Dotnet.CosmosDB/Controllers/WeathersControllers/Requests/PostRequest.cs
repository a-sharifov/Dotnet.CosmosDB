namespace Dotnet.CosmosDB.Controllers.WeathersControllers.Requests;

public sealed record PostRequest(
    int TemperatureC,
    //DateOnly Date,
    string Summary
    );
