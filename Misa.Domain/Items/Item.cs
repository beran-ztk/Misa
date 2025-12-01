using System.Runtime.CompilerServices;

namespace Misa.Domain.Items;

public class Item
{
    private Item() {}

    public Item(string title, string? description)
    {
        Title = title;
        Description = description;
    }
    
    public Guid Id { get; private set; }
    public string Title { get; private set; } 
    public string? Description { get; private set; }
    public DateTimeOffset CreateAtUtc { get; private set; }
}