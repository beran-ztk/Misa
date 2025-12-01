using Misa.Domain.Items;

namespace Misa.Application.Items;

public interface IItemRepository
{
    Task AddAsync(Item item, CancellationToken ct = default);
}