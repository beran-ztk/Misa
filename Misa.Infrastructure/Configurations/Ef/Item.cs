using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Misa.Infrastructure.Configurations.Ef;

public class Item : IEntityTypeConfiguration<Misa.Domain.Items.Item>
{
    public void Configure(EntityTypeBuilder<Misa.Domain.Items.Item> builder)
    {
        builder.ToTable("items");
        builder.HasKey(x => x.EntityId);
        builder.Property(x => x.EntityId)
            .HasColumnName("entity_id");
        builder.Property(x => x.StateId)
            .IsRequired()
            .HasColumnName("state_id");
        builder.Property(x => x.PriorityId)
            .IsRequired()
            .HasColumnName("priority_id");
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnName("title");
    }
}