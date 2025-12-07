namespace Misa.Contract.Items;

public class ItemDto
{
    public Guid EntityId { get; set; }
    public int StateId { get; set; } 
    public int PriorityId { get; set; }
    public string Title { get; set; }
}