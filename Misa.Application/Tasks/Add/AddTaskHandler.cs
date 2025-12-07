using Misa.Application.Entities.Add;
using Misa.Application.Entities.Mappings;
using Misa.Application.Items.Add;
using Misa.Contract.Entities;
using Misa.Contract.Items;
using Misa.Domain.Entities;
using Misa.Domain.Items;

namespace Misa.Application.Tasks.Add;

public class AddTaskHandler
{
    public async Task<Item> AddAsync(
        AddEntityHandler entityHandler,
        AddItemHandler itemHandler, 
        CancellationToken ct = default)
    {
        var entity = new Entity(null, (int)Misa.Domain.Dictionaries.Entities.EntityWorkflows.Task);
        entity = await entityHandler.AddAsync(entity, ct);

        var itemDto = new ItemDto
        {
            EntityId = entity.Id,
            StateId = (int)Misa.Domain.Dictionaries.Items.ItemStates.Draft,
            PriorityId = (int)Misa.Domain.Dictionaries.Items.ItemPriorities.None,
            Title = "New Task"
        };
        var item = AddItemCommand.Transform(itemDto, entity);
        return await itemHandler.AddAsync(item, ct);
    }
}