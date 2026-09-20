using KnowledgeForge.Api.Domain.Conversations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeForge.Api.Infrastructure.Persistence.Configurations;

public class MessageConfiguration
    : IEntityTypeConfiguration<Message>
{
    public void Configure(
        EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("messages");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Role)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Text)
            .IsRequired()
            .HasMaxLength(10_000);

        builder.Property(x => x.CreatedAt)
            .IsRequired();
    }
}