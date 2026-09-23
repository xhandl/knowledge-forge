using KnowledgeForge.Api.Domain.Conversations;
using KnowledgeForge.Api.Features.Conversations.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KnowledgeForge.Api.Features.Conversations;

public static class ConversationEndpoints
{
    public static IEndpointRouteBuilder MapConversationEndpoints(
        this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/conversations");

        group.MapPost("", CreateConversation)
            .WithName("CreateConversation");

        return endpoints;
    }

    private static async Task<Created<CreateConversationResponse>> CreateConversation(
        CreateConversationRequest request,
        IConversationService conversationService,
        CancellationToken cancellationToken)
    {
        var result = await conversationService.CreateAsync(
            request.Message,
            cancellationToken);

        var response = ToCreateConversationResponse(result);

        return TypedResults.Created(
            $"/api/conversations/{result.Id}",
            response);
    }

    private static CreateConversationResponse ToCreateConversationResponse(
        CreateConversationResult result)
    {
        var answer = new MessageResponse(
            result.Answer.Id,
            result.Answer.Text,
            ToMessageRoleResponse(result.Answer.Role),
            result.Answer.CreatedAt);

        return new CreateConversationResponse(
            result.Id,
            result.Name,
            answer);
    }

    private static MessageRoleResponse ToMessageRoleResponse(
    MessageRole role)
    {
        return role switch
        {
            MessageRole.User => MessageRoleResponse.User,
            MessageRole.Assistant => MessageRoleResponse.Assistant,
            _ => throw new ArgumentOutOfRangeException(
                nameof(role),
                role,
                "Unsupported message role.")
        };
    }
}