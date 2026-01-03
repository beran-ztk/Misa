namespace Misa.Application.Scheduling.Events.Commands;

public record ItemDeadlineUpsertedEvent(Guid ItemId, DateTimeOffset DueAtUtc);