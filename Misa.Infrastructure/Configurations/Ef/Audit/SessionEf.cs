using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misa.Domain.Audit;

namespace Misa.Infrastructure.Configurations.Ef.Audit;

public class SessionEf : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("audit_sessions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.EntityId)
            .HasColumnName("entity_id");

        builder.Property(x => x.EfficiencyId)
            .HasColumnName("efficiency_id");

        builder.Property(x => x.ConcentrationId)
            .HasColumnName("concentration_id");

        builder.Property(x => x.Objective)
            .HasColumnName("objective");

        builder.Property(x => x.Summary)
            .HasColumnName("summary");

        builder.Property(x => x.AutoStopReason)
            .HasColumnName("auto_stop_reason");

        // Postgres INTERVAL -> Npgsql mappt sauber auf TimeSpan
        builder.Property(x => x.PlannedDuration)
            .HasColumnName("planned_duration")
            .HasColumnType("interval");

        builder.Property(x => x.StopAutomatically)
            .HasColumnName("stop_automatically")
            .IsRequired();

        builder.Property(x => x.StartedAtUtc)
            .HasColumnName("started_at_utc")
            .IsRequired();

        builder.Property(x => x.EndedAtUtc)
            .HasColumnName("ended_at_utc");

        builder.HasOne(x => x.Efficiency)
            .WithMany()
            .HasForeignKey(x => x.EfficiencyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Concentration)
            .WithMany()
            .HasForeignKey(x => x.ConcentrationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.EntityId);
    }
}