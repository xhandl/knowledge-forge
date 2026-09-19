using Microsoft.AspNetCore.Http.HttpResults;

namespace KnowledgeForge.Api.Features.Chat;

public static class ChatEndpoints
{
    public static IEndpointRouteBuilder MapChatEndpoints(
        this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/chat");

        group.MapGet("", Ok<string> () => TypedResults.Ok("Hello from the Chat API!"));

        group.MapPost("",
            async Task<Ok<ChatResponse>> (
                ChatRequest request,
                IChatService chatService,
                CancellationToken cancellationToken) =>
            {
                var answer = await chatService.GetResponseAsync(
                    request.Message,
                    cancellationToken);

                return TypedResults.Ok(new ChatResponse(answer));
            })
            .WithName("CreateChatResponse");

        return endpoints;
    }
}