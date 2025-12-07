namespace Misa.Domain.Items;

public class Item
{
    private Item() {}

    public Item(Guid id, int stateId, int priorityId, string title)
    {
        EntityId = id;
        StateId = stateId;
        PriorityId = priorityId;
        Title = title;
    }
    
    public Guid EntityId { get; private set; }
    public int StateId { get; private set; } 
    public int PriorityId { get; private set; }
    public string Title { get; private set; }
}