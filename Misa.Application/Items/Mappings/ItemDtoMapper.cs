using Misa.Contract.Items;
using Misa.Domain.Entities;
using Misa.Domain.Items;

namespace Misa.Application.Items.Mappings;

public static class ItemDtoMapper
{
    public static Item ToDomain(this ItemDto dto, Entity entity)
    {
        return new Item
            (
                id: entity.Id,
                stateId:  dto.StateId,
                priorityId:  dto.PriorityId,
                title:  dto.Title
            );
    }
}