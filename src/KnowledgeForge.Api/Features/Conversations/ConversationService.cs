using KnowledgeForge.Api.Domain.Conversations;
using KnowledgeForge.Api.Infrastructure.AI;
using KnowledgeForge.Api.Infrastructure.Persistence;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using System.Net.NetworkInformation;

namespace KnowledgeForge.Api.Features.Conversations;

public class ConversationService(
    KnowledgeForgeDbContext dbContext,
    IChatClient chatClient,
    IOptions<AiOptions> aiOptions,
    TimeProvider timeProvider)
    : IConversationService
{
    private readonly KnowledgeForgeDbContext _dbContext = dbContext;
    private readonly IChatClient _chatClient = chatClient;
    private readonly AiOptions _aiOptions = aiOptions.Value;
    private readonly TimeProvider _timeProvider = timeProvider;

    public async Task<CreateConversationResult> CreateAsync(
        string message,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException(
                "Message cannot be empty.",
                nameof(message));
        }

        var createdAt = _timeProvider.GetUtcNow();

        var conversation = Conversation.Create(
            CreateConversationName(message),
            createdAt
        );

        conversation.AddMessage(
            MessageRole.User,
            message,
            createdAt
        );

        var messages = new List<ChatMessage>
        {
            new(ChatRole.System, _aiOptions.SystemMessage),
            new(ChatRole.User, message)
        };

        var answer = await _chatClient.GetResponseAsync(messages, options: null, cancellationToken);

        var answerMessage = conversation.AddMessage(
            MessageRole.Assistant,
            answer.Text,
            _timeProvider.GetUtcNow()
        );

        _dbContext.Conversations.Add(conversation);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CreateConversationResult(conversation.Id, conversation.Name, answerMessage);
    }

    private static string CreateConversationName(string message)
    {
        const int maxLength = 50;

        return message.Length <= maxLength
            ? message
            : message[..maxLength];
    }
}