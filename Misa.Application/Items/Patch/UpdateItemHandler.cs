using Misa.Application.Items.Repositories;
using Misa.Contract.Items;

namespace Misa.Application.Items.Patch;

public class UpdateItemHandler(IItemRepository repository)
{
    public async Task UpdateAsync(UpdateItemDto dto)
    {
        var item = await repository.GetTrackedItemAsync(dto.EntityId);
        
        if (dto.Title != null)
            item.Rename(dto.Title);
        
        if (dto.StateId != null)
            item.ChangeState((int)dto.StateId);
        
        if (dto.PriorityId.HasValue)
            item.ChangePriority((int)dto.PriorityId);
        
        if (dto.CategoryId.HasValue)
            item.ChangeCategory((int)dto.CategoryId);
        
        await repository.SaveChangesAsync();
    }
}