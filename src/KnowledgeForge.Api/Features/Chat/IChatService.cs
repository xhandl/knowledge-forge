namespace KnowledgeForge.Api.Features.Chat;

public interface IChatService
{
    Task<string> GetResponseAsync(string message, CancellationToken cancellationToken);
}