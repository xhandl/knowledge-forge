using KnowledgeForge.Api.Features.Conversations.Contracts;
using System.Text.Json.Serialization;

namespace KnowledgeForge.Api.Serialization;

[JsonSerializable(typeof(CreateConversationRequest))]
[JsonSerializable(typeof(CreateConversationResponse))]
public partial class AppJsonSerializerContext : JsonSerializerContext
{
}