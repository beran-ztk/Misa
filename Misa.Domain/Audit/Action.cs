namespace Misa.Domain.Audit;

public class Action
{
    public Guid Id { get; private set; }
    public Guid EntityId { get; private set; }

    public int TypeId { get; private set; }
    public ActionType Type { get; private set; } = null!;

    public string? ValueBefore { get; private set; }
    public string? ValueAfter { get; private set; }

    public string? Reason { get; private set; }

    public DateTimeOffset CreatedAtUtc { get; private set; }

    // optional Factory/Constructor für UseCases
    public static Action Create(Guid entityId, int typeId, string? before, string? after, string? reason, DateTimeOffset nowUtc)
        => new()
        {
            Id = Guid.NewGuid(),
            EntityId = entityId,
            TypeId = typeId,
            ValueBefore = before,
            ValueAfter = after,
            Reason = reason,
            CreatedAtUtc = nowUtc
        };
}