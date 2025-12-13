using Microsoft.EntityFrameworkCore;
using Misa.Application.Main.Repositories;
using Misa.Contract.Audit.Lookups;
using Misa.Contract.Items.Lookups;
using Misa.Domain.Audit;
using Misa.Domain.Main;
using Misa.Infrastructure.Configurations.Ef;
using Misa.Infrastructure.Data;
using Category = Misa.Domain.Items.Category;
using Priority = Misa.Domain.Items.Priority;
using State = Misa.Domain.Items.State;

namespace Misa.Infrastructure.Main;

public class MainRepository(MisaDbContext db) : IMainRepository
{
    public async Task AddDescriptionAsync(Description description)
    {
        await db.Descriptions.AddAsync(description);
        await db.SaveChangesAsync();
    }
    public async Task<List<State>> GetStatesForCreation(CancellationToken ct)
        => await db.States
            .Where(s 
                => s.Id == (int)Misa.Domain.Dictionaries.Items.ItemStates.Draft
                || s.Id == (int)Misa.Domain.Dictionaries.Items.ItemStates.Open
                || s.Id == (int)Misa.Domain.Dictionaries.Items.ItemStates.Done
                || s.Id == (int)Misa.Domain.Dictionaries.Items.ItemStates.Archived)
            .ToListAsync(ct);

    public async Task<List<Priority>> GetPriorities(CancellationToken ct)
        => await db.Priorities.ToListAsync(ct);

    public async Task<List<Category>> GetTaskCategories(CancellationToken ct)
        => await db.Categories.ToListAsync(ct);
    public async Task<List<SessionEfficiencyType>> GetEfficiencyTypes(CancellationToken ct)
        => await db.EfficiencyTypes.ToListAsync(ct);
    public async Task<List<SessionConcentrationType>> GetConcentrationTypes(CancellationToken ct)
        => await db.ConcentrationTypes.ToListAsync(ct);
}