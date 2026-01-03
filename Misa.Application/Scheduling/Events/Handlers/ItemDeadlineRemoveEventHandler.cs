using Misa.Application.Scheduling.Events.Commands;

namespace Misa.Application.Scheduling.Events.Handlers;

public class ItemDeadlineRemoveEventHandler
{
    public static Task Handle(ItemDeadlineRemovedEvent e, CancellationToken ct)
    {
        Console.WriteLine($"Deadline removed: ItemId={e.ItemId}");
        return Task.CompletedTask;
    }
}