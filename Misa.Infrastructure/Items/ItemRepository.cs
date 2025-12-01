using Misa.Domain.Items;
using Misa.Application.Items;
using Misa.Infrastructure.Data;

namespace Misa.Infrastructure.Items;

public class ItemRepository(MisaDbContext db) : IItemRepository
{
    public async Task AddAsync(Item item, CancellationToken ct = default)
    {
        await db.Items.AddAsync(item, ct)
            .ConfigureAwait(false);
        await db.SaveChangesAsync(ct);
    }
}