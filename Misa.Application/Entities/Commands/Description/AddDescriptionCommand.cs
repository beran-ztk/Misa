namespace Misa.Application.Entities.Commands.Description;

public record AddDescriptionCommand(Guid EntityId, string Content);