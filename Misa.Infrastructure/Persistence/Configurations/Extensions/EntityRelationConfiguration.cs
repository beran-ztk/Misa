using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Misa.Infrastructure.Persistence.Configurations.Extensions;

public class EntityRelationConfiguration : IEntityTypeConfiguration<Domain.Extensions.Relations>
{
    public void Configure(EntityTypeBuilder<Domain.Extensions.Relations> builder)
    {
        builder.ToTable("relations");

        builder.HasKey(s => s.EntityId);

        builder.Property(s => s.EntityId)
            .HasColumnName("entity_id");
        
        builder.Property(s => s.ParentId)
            .IsRequired()
            .HasColumnName("entity_parent_id");
        
        builder.Property(s => s.ChildId)
            .IsRequired()
            .HasColumnName("entity_child_id");
        
        builder.Property(s => s.RelationId)
            .IsRequired()
            .HasColumnName("relation_id");

        builder.HasOne<Domain.Entities.Entity>()
            .WithOne()
            .HasForeignKey<Domain.Extensions.Relations>(s => s.EntityId);
    }
}