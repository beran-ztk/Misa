using Misa.Domain.Items;
using Misa.Application.Items.Repositories;
using Misa.Infrastructure.Data;

namespace Misa.Infrastructure.Items;

public class ItemRepository(MisaDbContext db) : IItemRepository
{
    public async Task<Item> AddAsync(Item item, CancellationToken ct = default)
    {
        await db.Items.AddAsync(item, ct);
        await db.SaveChangesAsync(ct);
        return item;
    }
}