using Microsoft.AspNetCore.Mvc;
using Misa.Application.Common.Abstractions.Events;
using Misa.Application.Scheduling.Commands.Deadlines;
using Misa.Contract.Events;
using Misa.Contract.Scheduling;
using Wolverine;

namespace Misa.Api.Endpoints.Scheduling;
public static class DeadlineEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapPut("/items/{itemId:guid}/deadline", UpsertDeadline);
        app.MapDelete("/items/{itemId:guid}/deadline", RemoveDeadline);
    }

    private static async Task<IResult> UpsertDeadline(
        [FromRoute] Guid itemId,
        [FromBody] ScheduleDeadlineDto dto,
        IMessageBus bus,
        CancellationToken ct)
    {
        await bus.InvokeAsync(new UpsertItemDeadlineCommand(itemId, dto.DeadlineAt), ct);
        return Results.NoContent();
    }

    private static async Task<IResult> RemoveDeadline(
        [FromRoute] Guid itemId,
        IMessageBus bus,
        IEventPublisher events,
        CancellationToken ct)
    {
        await bus.InvokeAsync(new RemoveItemDeadlineCommand(itemId), ct);

        await events.PublishAsync(new EventDto
        {
            EventType = "DeadlineRemoved",
            Payload = System.Text.Json.JsonSerializer.Serialize(new { itemId }),
            TimestampUtc = DateTimeOffset.UtcNow
        }, ct);
        
        return Results.NoContent();
    }
}

