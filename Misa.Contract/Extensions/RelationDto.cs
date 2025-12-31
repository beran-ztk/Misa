namespace Misa.Contract.Extensions;

public record RelationDto(Guid EntityId, Guid ParentId, Guid ChildId, int RelationId);