using Misa.Domain.Items;
using Misa.Contract.Items;

namespace Misa.Api.Items;

public static class ItemMappings
{
    public static Item ToDomain(this ItemDto dto)
        => new Item
        (
            dto.Title, 
            dto.Description
        );
}
