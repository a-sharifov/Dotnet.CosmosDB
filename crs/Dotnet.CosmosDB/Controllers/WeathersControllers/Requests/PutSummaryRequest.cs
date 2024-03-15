namespace Dotnet.CosmosDB.Controllers.WeathersControllers.Requests;

public sealed record PutSummaryRequest(
    string Id, 
    string Summary
    );
