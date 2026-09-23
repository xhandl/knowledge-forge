namespace KnowledgeForge.Api.Features.Conversations.Contracts;

public record MessageResponse(
    Guid Id,
    string Text,
    MessageRoleResponse Role,
    DateTimeOffset CreatedAt);