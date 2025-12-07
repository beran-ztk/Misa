using Misa.Application.Entities.Mappings;
using Misa.Application.Entities.Repositories;
using Misa.Contract.Entities;

namespace Misa.Application.Entities.Get;

public class GetEntitiesHandler(IEntityRepository repository)
{
    public async Task<List<EntityDto>> GetAllAsync(CancellationToken ct = default)
    {
        List<Misa.Contract.Entities.EntityDto> dto = [];
        
        var entities = await repository.GetAllAsync(ct);

        dto.AddRange(entities.Select(entity => entity.ToDto()));

        return dto;
    }
}