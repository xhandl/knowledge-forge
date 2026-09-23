using Microsoft.Extensions.Options;

namespace KnowledgeForge.Api.Infrastructure.AI;

[OptionsValidator]
public partial class AiOptionsValidator
    : IValidateOptions<AiOptions>
{
}