namespace KnowledgeForge.Api.Domain.Conversations;

public class Conversation
{
    private Conversation(
        Guid id,
        string name,
        DateTimeOffset createdAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = createdAt;
    }

    private readonly List<Message> _messages = [];

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }

    public IReadOnlyCollection<Message> Messages => _messages;

    public static Conversation Create(
        string name,
        DateTimeOffset createdAt)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Conversation name cannot be empty.",
                nameof(name));
        }

        return new Conversation(
            Guid.NewGuid(),
            name,
            createdAt);
    }

    public Message AddMessage(
        MessageRole role,
        string text,
        DateTimeOffset createdAt)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException(
                "Message text cannot be empty.",
                nameof(text));
        }

        var message = new Message(
            Guid.NewGuid(),
            Id,
            role,
            text,
            createdAt);

        _messages.Add(message);
        UpdatedAt = createdAt;

        return message;
    }
}