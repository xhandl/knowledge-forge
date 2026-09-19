using System.ComponentModel.DataAnnotations;

namespace KnowledgeForge.Api.Features.Chat;

public sealed class ChatOptions
{
    public const string SectionName = "Chat";

    [Required]
    public string SystemMessage { get; set; } = string.Empty;
}