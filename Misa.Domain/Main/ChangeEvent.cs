namespace Misa.Domain.Main;

public interface IDomainEvent { }

public interface IHasDomainEvents
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}

public abstract class ChangeEvent : IHasDomainEvents
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

    protected void AddDomainEvent(IDomainEvent ev) => _domainEvents.Add(ev);
    public void ClearDomainEvents() => _domainEvents.Clear();
}

public sealed record PropertyChangedEvent(
    Guid EntityId,
    int ActionType,
    string? OldValue,
    string? NewValue,
    string? Reason
) : IDomainEvent;