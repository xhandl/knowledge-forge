using KnowledgeForge.Api.Domain.Conversations;

namespace KnowledgeForge.Api.Features.Conversations;

public record CreateConversationResult(
    Guid Id,
    string Name,
    Message Answer);