using Microsoft.AspNetCore.SignalR;
using Misa.Application.Common.Abstractions.Events;
using Misa.Contract.Events;

namespace Misa.Api.Common.Realtime;

public sealed class SignalREventPublisher : IEventPublisher
{
    private readonly IHubContext<EventsHub> _hub;

    public SignalREventPublisher(IHubContext<EventsHub> hub) => _hub = hub;

    public Task PublishAsync(EventDto evt, CancellationToken ct = default)
        => _hub.Clients.All.SendCoreAsync("event", [evt], ct);
}