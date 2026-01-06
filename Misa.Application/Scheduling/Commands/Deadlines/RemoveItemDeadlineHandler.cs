using System.ComponentModel.DataAnnotations;
using Misa.Application.Common.Abstractions.Persistence;
using Misa.Application.Common.Exceptions;
using Misa.Application.Scheduling.Events.Commands;
using Wolverine;

namespace Misa.Application.Scheduling.Commands.Deadlines;

public sealed class RemoveItemDeadlineHandler(IItemRepository repository, IMessageBus bus)
{
    public async Task Handle(RemoveItemDeadlineCommand command, CancellationToken ct)
    {
        if (command.ItemId == Guid.Empty)
        {
            throw new ValidationException("ItemId must not be empty.");
        }

        var item = await repository.TryGetItemAsync(command.ItemId);
        if (item is null)
        {
            throw NotFoundException.For("Item", command.ItemId);
        }

        var deadlineEntry = await repository.TryGetScheduledDeadlineForItemAsync(command.ItemId, ct);
        if (deadlineEntry is null)
        {
            return;
        }

        deadlineEntry.RescheduleDeadlineAndAuditChanges(null);
        await repository.RemoveScheduledDeadlineAsync(deadlineEntry, ct);
        
        await repository.SaveChangesAsync(ct);

        await bus.PublishAsync(new ItemDeadlineRemovedEvent(command.ItemId));
    }
}