namespace KnowledgeForge.Api.Features.Conversations;

public static class DependencyInjection
{
    public static IServiceCollection AddConversations(
    this IServiceCollection services)
    {
        services.AddScoped<IConversationService, ConversationService>();
        services.AddScoped<IConversationService, ConversationService>();

        return services;
    }
}