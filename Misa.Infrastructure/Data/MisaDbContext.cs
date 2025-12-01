using Misa.Domain.Items;
using Microsoft.EntityFrameworkCore;

namespace Misa.Infrastructure.Data;

public class MisaDbContext : DbContext
{
    public MisaDbContext(DbContextOptions<MisaDbContext> options) 
        : base(options) {}
    
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("items");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnName("title");
            entity.Property(e => e.Description)
                .HasColumnName("description");
            entity.Property(e => e.CreateAtUtc)
                .HasColumnName("created_at_utc");
        });
    }
}