using Misa.Domain.Entities;
using Misa.Domain.Entities.Extensions;

namespace Misa.Application.Common.Abstractions.Persistence;

public interface IEntityRepository
{
    public Task<Entity> GetTrackedEntityAsync(Guid id);
    public Task SaveChangesAsync();
    public Task<Misa.Domain.Entities.Entity> AddAsync(Misa.Domain.Entities.Entity entity, CancellationToken ct);
    public Task<List<Misa.Domain.Entities.Entity>> GetAllAsync(CancellationToken ct);
    public Task<Entity?> GetDetailedEntityAsync(Guid id, CancellationToken ct = default);
    public Task AddDescriptionAsync(Description description, CancellationToken ct);

}