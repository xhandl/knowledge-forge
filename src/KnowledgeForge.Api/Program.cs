using KnowledgeForge.Api.Features.Chat;
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
builder.Services.AddChat(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapChatEndpoints();

app.Run();