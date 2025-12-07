namespace Misa.Contract.Entities;

public class EntityDto
{
    public Guid Id { get; set; }
    public Guid? OwnerId { get; set; }
    public int WorkflowId { get; set; }
    public bool IsDeleted { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset InteractedAt { get; set; }
}