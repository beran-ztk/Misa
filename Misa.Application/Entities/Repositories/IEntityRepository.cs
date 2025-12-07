namespace Misa.Application.Entities.Repositories;

public interface IEntityRepository
{
    public Task<Misa.Domain.Entities.Entity> AddAsync(Misa.Domain.Entities.Entity entity, CancellationToken ct);
    public Task<List<Misa.Domain.Entities.Entity>> GetAllAsync(CancellationToken ct);
}