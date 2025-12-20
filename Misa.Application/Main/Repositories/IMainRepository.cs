using Misa.Contract.Audit.Lookups;
using Misa.Contract.Items.Lookups;
using Misa.Domain.Audit;
using Misa.Domain.Items;
using Misa.Domain.Main;

namespace Misa.Application.Main.Repositories;

public interface IMainRepository
{
    public Task AddDescriptionAsync(Description description);
    public Task<List<Priority>> GetPriorities(CancellationToken ct);
    public Task<List<Category>> GetTaskCategories(CancellationToken ct);
    public Task<List<SessionEfficiencyType>> GetEfficiencyTypes(CancellationToken ct);
    public Task<List<SessionConcentrationType>> GetConcentrationTypes(CancellationToken ct);
}