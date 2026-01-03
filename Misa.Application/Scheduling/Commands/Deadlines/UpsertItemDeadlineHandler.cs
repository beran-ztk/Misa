using System.ComponentModel.DataAnnotations;
using Misa.Application.Common.Abstractions.Persistence;
using Misa.Application.Common.Exceptions;
using Misa.Application.Scheduling.Events;
using Misa.Application.Scheduling.Events.Commands;
using Wolverine;

namespace Misa.Application.Scheduling.Commands.Deadlines;

public sealed class UpsertItemDeadlineHandler(IItemRepository repository, IMessageBus bus)
{
    public async Task Handle(UpsertItemDeadlineCommand command, CancellationToken ct = default)
    {
        if (command.ItemId == Guid.Empty)
            throw new ValidationException("ItemId must not be empty.");

        if (command.DueAt == default)
            throw new ValidationException("DueAt must be specified.");

        var item = await repository.GetTrackedItemAsync(command.ItemId);
        if (item is null)
            throw NotFoundException.For("Item", command.ItemId);

        var dueAtUtc = command.DueAt.ToUniversalTime();
        if (dueAtUtc < DateTimeOffset.UtcNow)
            throw new ValidationException("DueAt must not be in the past."); 
        
        await repository.UpsertDeadlineAsync(command.ItemId, dueAtUtc, ct);
        
        await repository.SaveChangesAsync(ct);

        await bus.PublishAsync(new ItemDeadlineUpsertedEvent(command.ItemId, dueAtUtc));
    }
}