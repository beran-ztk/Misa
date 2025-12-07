using Misa.Application.Items.Mappings;
using Misa.Contract.Items;
using Misa.Domain.Entities;
using Misa.Domain.Items;

namespace Misa.Application.Items.Add;

public static class AddItemCommand
{
    public static Item Transform(ItemDto dto, Entity entity)
    {
        return dto.ToDomain(entity);
    }
}