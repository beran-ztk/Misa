using Misa.Application.Scheduling.Events.Commands;

namespace Misa.Application.Scheduling.Events.Handlers;

public class ItemDeadlineUpsertedEventHandler
{
    public static Task Handle(ItemDeadlineUpsertedEvent e, CancellationToken ct)
    {
        Console.WriteLine($"Deadline upserted: ItemId={e.ItemId}, DueAt={e.DueAtUtc}");
        return Task.CompletedTask;
    }
}