using Misa.Contract.Events;

namespace Misa.Application.Common.Abstractions.Events;

public interface IEventPublisher
{
    Task PublishAsync(EventDto evt, CancellationToken ct = default);
}