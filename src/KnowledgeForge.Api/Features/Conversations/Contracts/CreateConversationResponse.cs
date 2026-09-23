namespace KnowledgeForge.Api.Features.Conversations.Contracts;

public record CreateConversationResponse(
    Guid Id,
    string Name,
    MessageResponse Answer);