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
    public DbSet<Misa.Domain.Items.State> States { get; set; } = null;
    public DbSet<Misa.Domain.Items.Priority> Priorities { get; set; } = null;
    public DbSet<Misa.Domain.Items.Category> Categories { get; set; } = null;
    public DbSet<Misa.Domain.Entities.Workflow> Workflows { get; set; } = null;
    public DbSet<Misa.Domain.Main.Description> Descriptions { get; set; } = null;
    public DbSet<Misa.Domain.Main.DescriptionTypes> DescriptionTypes { get; set; } = null;
    
    public DbSet<Misa.Domain.Audit.Session> Sessions { get; set; } = null;
    public DbSet<Misa.Domain.Audit.SessionEfficiencyType> EfficiencyTypes { get; set; } = null;
    public DbSet<Misa.Domain.Audit.SessionConcentrationType> ConcentrationTypes { get; set; } = null;
    public DbSet<Misa.Domain.Audit.Action> Actions { get; set; } = null;
    public DbSet<Misa.Domain.Audit.ActionType> ActionTypes { get; set; } = null;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MisaDbContext).Assembly);
    }
}