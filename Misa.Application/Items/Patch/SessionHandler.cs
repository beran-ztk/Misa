using Misa.Application.Items.Repositories;
using Misa.Contract.Audit;
using Misa.Domain.Audit;

namespace Misa.Application.Items.Patch;

public class SessionHandler(IItemRepository repository)
{
    public async Task<bool> StartSessionAsync(SessionDto dto)
    {
        var item = await repository.GetTrackedItemAsync(dto.EntityId);
        item.StartSession();

        var session = Session.Start
        (
            dto.EntityId, dto.PlannedDuration, dto.Objective, 
            dto.StopAutomatically, dto.AutoStopReason, DateTimeOffset.UtcNow
        );
        await repository.AddAsync(session);
        
        await repository.SaveChangesAsync();
        return true;
    }
    public async Task<bool> PauseSessionAsync(SessionDto dto)
    {
        var item = await repository.GetTrackedItemAsync(dto.EntityId);
        item.PauseSession();

        var session = await repository.GetTrackedSessionAsync(dto.EntityId);
        session.Pause(dto.EfficiencyId, dto.ConcentrationId, dto.Summary, DateTimeOffset.UtcNow);
        await repository.SaveChangesAsync();
        return true;
    }
}