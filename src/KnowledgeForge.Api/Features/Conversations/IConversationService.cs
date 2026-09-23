namespace KnowledgeForge.Api.Features.Conversations;

public interface IConversationService
{
    Task<CreateConversationResult> CreateAsync(
        string message,
        CancellationToken cancellationToken);
}