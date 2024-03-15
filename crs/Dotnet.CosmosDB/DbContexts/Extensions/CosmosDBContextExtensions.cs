using Dotnet.CosmosDB.DbContexts.Abstractions;
using Dotnet.CosmosDB.DbContexts.Interfaces;
using Dotnet.CosmosDB.DbContexts.Options;

namespace Dotnet.CosmosDB.DbContexts.Extensions;

public static class CosmosDBContextExtensions
{
    public static IServiceCollection AddCosmosDBContext<TCosmosDBContext>(
        this IServiceCollection services, Action<CosmosDBContextOptions<TCosmosDBContext>> action)
          where TCosmosDBContext : CosmosDBContext
    {
        services.AddOptions<CosmosDBContextOptions<TCosmosDBContext>>().Configure(action);
        services.AddTransient<TCosmosDBContext>();
        return services;
    }

    public static IApplicationBuilder CreateDatabaseIfNotExists<TCosmosDBContext>
        (this IApplicationBuilder builder)
        where TCosmosDBContext : CosmosDBContext
    {
        using var scope = builder.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TCosmosDBContext>();
        context.CreateDatabaseAsync().Wait();
        return builder;
    }

    public static IApplicationBuilder CreateContainerIfNotExists<TCosmosDBContext>
        (this IApplicationBuilder builder, string containerName)
        where TCosmosDBContext : CosmosDBContext
    {
        using var scope = builder.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TCosmosDBContext>();
        context.CreateContainerAsync(containerName).Wait();
        return builder;
    }

    public static IApplicationBuilder CreateContainerIfNotExists<TCosmosDBContext, TEntity>
        (this IApplicationBuilder builder)
        where TCosmosDBContext : CosmosDBContext
        where TEntity : ICosmosEntity
    {
        using var scope = builder.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TCosmosDBContext>();
        context.CreateContainerAsync<TEntity>().Wait();
        return builder;
    }
}
