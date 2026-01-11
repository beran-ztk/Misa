using Misa.Application.Common.Abstractions.Persistence;

namespace Misa.Application.Items.Commands;

public class StartSessionHandler(IItemRepository repository)
{
    public async Task Handle(StartSessionCommand cmd, CancellationToken ct)
    {
        var item = await repository.TryGetItemAsync(resolvedDto.EntityId, CancellationToken.None);
        item.StartSession(ref hasBeenChanged);

        var session = Session.Start
        (
            resolvedDto.EntityId, resolvedDto.PlannedDuration, resolvedDto.Objective, 
            resolvedDto.StopAutomatically, resolvedDto.AutoStopReason, DateTimeOffset.UtcNow
        );
        
        if (!hasBeenChanged)
            return;
        
        item.Entity.Update();
        var loadedSession = await repository.AddSessionAsync(session);

        var segment = new SessionSegment(loadedSession.Id, DateTimeOffset.UtcNow);
        
        await repository.AddAsync(segment);
    }
}