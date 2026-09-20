using Microsoft.EntityFrameworkCore;

namespace KnowledgeForge.Api.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("KnowledgeForge")
            ?? throw new InvalidOperationException(
                "Connection string is not configured.");

        services.AddDbContext<KnowledgeForgeDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}