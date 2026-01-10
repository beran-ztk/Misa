using Microsoft.AspNetCore.Mvc;
using Misa.Application.Entities.Commands.Description;
using Misa.Contract.Common.Results;
using Misa.Contract.Entities.Features;
using Wolverine;

namespace Misa.Api.Endpoints.Entities;

public static class DescriptionEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapPost("entities/description", AddDescription);
    }

    private static async Task<Result<DescriptionDto>> AddDescription(
        [FromBody] DescriptionCreateDto dto,
        IMessageBus bus,
        CancellationToken ct = default)
    {
        var cmd = new AddDescriptionCommand(dto.EntityId, dto.Content);
        
        var res = await bus.InvokeAsync<Result<DescriptionDto>>(cmd, ct);
        
        return res;
    }
}