using Microsoft.Extensions.Options;

namespace KnowledgeForge.Api.Features.Chat;

[OptionsValidator]
public partial class ChatOptionsValidator
    : IValidateOptions<ChatOptions>
{
}