using System.ComponentModel.DataAnnotations;

namespace KnowledgeForge.Api.Infrastructure.AI;

public sealed class AiOptions
{
    public const string SectionName = "AI";

    [Required]
    public string SystemMessage { get; set; } = string.Empty;
}