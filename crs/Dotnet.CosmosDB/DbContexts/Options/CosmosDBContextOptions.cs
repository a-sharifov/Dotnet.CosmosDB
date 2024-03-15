namespace Dotnet.CosmosDB.DbContexts.Options;

public abstract class CosmosDBContextOptions
{
    public string Endpoint { get; set; }

    public string Key { get; set; }

    public string DatabaseName { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected CosmosDBContextOptions() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
