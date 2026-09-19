using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;

namespace KnowledgeForge.Api.Features.Chat;

public class ChatService(IChatClient chatClient, IOptions<ChatOptions> options) : IChatService
{
    private readonly IChatClient _chatClient = chatClient;
    private readonly ChatOptions _options = options.Value;

    public async Task<string> GetResponseAsync(string message, CancellationToken cancellationToken)
    {
        var messages = new List<ChatMessage>
        {
            new(ChatRole.System, _options.SystemMessage),
            new(ChatRole.User, message)
        };

        var response = await _chatClient.GetResponseAsync(messages, options: null, cancellationToken);

        return response.Text;
    }
}