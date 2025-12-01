using Misa.Domain.Items;

namespace Misa.Application.Items;

public class ItemCreationHandler(IItemRepository itemRepository)
{
    public async Task MapAsync()
    {
        
    }
    public async Task HandleAsync(Item item, CancellationToken ct = default)
    {
        await itemRepository.AddAsync(item, ct);
    }
}