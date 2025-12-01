namespace Misa.Contract.Items;

public class ItemDto
{
    public ItemDto(string title, string description)
    {
        Title = title;
        Description = description;
    }
    
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public DateTimeOffset CreateAtUtc { get; private set; }
}