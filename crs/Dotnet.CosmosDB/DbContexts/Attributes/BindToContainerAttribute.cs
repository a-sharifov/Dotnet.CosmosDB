namespace Dotnet.CosmosDB.DbContexts.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class BindToContainerAttribute(string containerName) : Attribute
{
    public readonly string ContainerName = containerName;
}