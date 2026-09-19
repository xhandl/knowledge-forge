namespace KnowledgeForge.Api.Features.Chat;

public static class DependencyInjection
{
    public static IServiceCollection AddChat(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
        .AddOptionsWithValidateOnStart<ChatOptions, ChatOptionsValidator>()
        .Bind(configuration.GetSection(ChatOptions.SectionName));

        services.AddScoped<IChatService, ChatService>();

        return services;
    }
}