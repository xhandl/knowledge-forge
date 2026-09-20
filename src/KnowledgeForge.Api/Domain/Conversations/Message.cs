namespace KnowledgeForge.Api.Domain.Conversations;

public class Message
{
    internal Message(
        Guid id,
        Guid conversationId,
        MessageRole role,
        string text,
        DateTimeOffset createdAt)
    {
        Id = id;
        ConversationId = conversationId;
        Role = role;
        Text = text;
        CreatedAt = createdAt;
    }

    public Guid Id { get; private set; }
    public Guid ConversationId { get; private set; }
    public MessageRole Role { get; private set; }
    public string Text { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
}