using KnowledgeForge.Api.Features.Chat;
using System.Text.Json.Serialization;

namespace KnowledgeForge.Api.Serialization;

[JsonSerializable(typeof(ChatRequest))]
[JsonSerializable(typeof(ChatResponse))]
public partial class AppJsonSerializerContext : JsonSerializerContext
{
}