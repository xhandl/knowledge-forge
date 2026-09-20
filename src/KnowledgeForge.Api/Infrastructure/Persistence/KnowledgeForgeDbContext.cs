using KnowledgeForge.Api.Domain.Conversations;
using KnowledgeForge.Api.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeForge.Api.Infrastructure.Persistence;

public class KnowledgeForgeDbContext : DbContext
{
    public KnowledgeForgeDbContext(DbContextOptions<KnowledgeForgeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Conversation> Conversations => Set<Conversation>();
    public DbSet<Message> Messages => Set<Message>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(
            new ConversationConfiguration());

        modelBuilder.ApplyConfiguration(
            new MessageConfiguration());
    }
}