namespace Misa.Domain.Common.DomainEvents;

public sealed record PropertyChangedEvent(
    Guid EntityId,
    int ActionType,
    string? OldValue,
    string? NewValue,
    string? Reason
) : IDomainEvent;