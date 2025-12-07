using Misa.Contract.Entities;

namespace Misa.Application.Entities.Mappings;

public static class EntityDtoMapper
{
    public static Misa.Domain.Entities.Entity ToDomain(this Misa.Contract.Entities.EntityDto entity)
        => new
        (
            ownerId: entity.OwnerId,
            workflowId: entity.WorkflowId
        );
    public static Misa.Contract.Entities.EntityDto ToDto(this Misa.Domain.Entities.Entity entity)
        => new EntityDto()
        {
            Id = entity.Id,
            OwnerId = entity.OwnerId,
            WorkflowId = entity.WorkflowId,
            IsDeleted = entity.IsDeleted,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            InteractedAt = entity.InteractedAt
        };
}