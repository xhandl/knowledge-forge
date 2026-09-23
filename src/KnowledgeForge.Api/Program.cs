using KnowledgeForge.Api.Features.Conversations;
using KnowledgeForge.Api.Infrastructure.AI;
using KnowledgeForge.Api.Infrastructure.Persistence;
using KnowledgeForge.Api.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddOpenApi();

builder.Services.AddAi(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddConversations();
builder.Services.AddSingleton(TimeProvider.System);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () => Results.Redirect("openapi/v1.json"));
app.MapConversationEndpoints();

app.Run();