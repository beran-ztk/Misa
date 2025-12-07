using Misa.Domain.Items;

namespace Misa.Application.Items.Repositories;

public interface IItemRepository
{
    Task<Item> AddAsync(Item item, CancellationToken ct = default);
}