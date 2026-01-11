using Microsoft.AspNetCore.Mvc;
using Misa.Application.Items.Commands;
using Misa.Application.Items.Queries;
using Misa.Contract.Audit.Session;
using Misa.Contract.Common.Results;
using Misa.Contract.Items.Details;
using Wolverine;

namespace Misa.Api.Endpoints.Items;

public static class ItemDetailEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("items/{itemId:guid}/overview", GetDetails);
        app.MapPost("items/{itemId:guid}/sessions/start", StartSession);
    }

    private static async Task<Result<ItemOverviewDto>> GetDetails(
        [FromRoute] Guid itemId,
        IMessageBus bus, 
        CancellationToken ct)
    {
        var res = await bus.InvokeAsync<Result<ItemOverviewDto>>(new GetItemDetailsQuery(itemId), ct);
        return res;
    }
    private static async Task<Result> StartSession(
        [FromRoute] Guid itemId,
        [FromBody] StartSessionDto dto,
        IMessageBus bus, 
        CancellationToken ct)
    {
        var cmd = new StartSessionCommand(
            dto.ItemId, 
            dto.PlannedDuration, 
            dto.Objective, 
            dto.StopAutomatically,
            dto.AutoStopReason
        );
        
        var res = await bus.InvokeAsync<Result>(cmd, ct);
        
        return res;
    }
}