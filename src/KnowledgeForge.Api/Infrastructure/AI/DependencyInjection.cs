using Microsoft.Extensions.AI;
using OpenAI;

namespace KnowledgeForge.Api.Infrastructure.AI;

public static class DependencyInjection
{
    public static IServiceCollection AddAi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var apiKey = configuration["OpenAI:ApiKey"]
            ?? throw new InvalidOperationException(
                "OpenAI API key is not configured.");

        var model = configuration["OpenAI:Model"]
            ?? throw new InvalidOperationException(
                "OpenAI model is not configured.");

        var chatClient = new OpenAIClient(apiKey)
            .GetChatClient(model)
            .AsIChatClient();

        services.AddSingleton<IChatClient>(chatClient);

        services
           .AddOptionsWithValidateOnStart<AiOptions, AiOptionsValidator>()
           .Bind(configuration.GetSection(AiOptions.SectionName));

        return services;
    }
}