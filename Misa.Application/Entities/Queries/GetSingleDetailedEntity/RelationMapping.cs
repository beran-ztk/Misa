using Misa.Contract.Extensions;
using Misa.Domain.Extensions;

namespace Misa.Application.Entities.Queries.GetSingleDetailedEntity;

public static class RelationMapping
{
    public static List<RelationDto> ToDto(this ICollection<Relations> relations)
        => relations
            .Select(r => new RelationDto(r.EntityId, r.ParentId, r.ChildId, r.RelationId))
            .ToList();
}