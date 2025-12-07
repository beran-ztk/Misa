using Misa.Domain.Items;
using Microsoft.EntityFrameworkCore;
using Misa.Domain.Entities;

namespace Misa.Infrastructure.Data;

public class MisaDbContext : DbContext
{
    public MisaDbContext(DbContextOptions<MisaDbContext> options) 
        : base(options) {}

    public DbSet<Misa.Domain.Entities.Entity> Entities { get; set; } = null;
    public DbSet<Misa.Domain.Items.Item> Items { get; set; } = null;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MisaDbContext).Assembly);
    }
}