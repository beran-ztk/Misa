using Misa.Application.Common.Abstractions.Persistence;
using Misa.Application.Items.Mappings;
using Misa.Contract.Common.Results;
using Misa.Contract.Entities.Features;

namespace Misa.Application.Entities.Commands.Description;

public class AddDescriptionHandler(IEntityRepository repository)
{
    public async Task<Result<DescriptionDto>> Handle(AddDescriptionCommand cmd, CancellationToken ct)
    {
        var description = Domain.Entities.Extensions.Description.Create(cmd.EntityId, cmd.Content);
        
        await repository.AddDescriptionAsync(description, ct);
        await repository.SaveChangesAsync();

        var descriptionDto = description.ToDto();

        return Result<DescriptionDto>.Ok(descriptionDto);
    }
}