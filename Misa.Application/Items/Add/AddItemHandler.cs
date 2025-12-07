using Misa.Application.Items.Repositories;
using Misa.Domain.Entities;
using Misa.Domain.Items;

namespace Misa.Application.Items.Add;

public class AddItemHandler(IItemRepository repository)
{
    public async Task<Item> AddAsync(Item item, CancellationToken ct = default)
    {
        return await repository.AddAsync(item, ct);
    }
}