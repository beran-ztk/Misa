using Misa.Domain.Dictionaries.Audit;
using Misa.Domain.Entities;
using Misa.Domain.Main;

namespace Misa.Domain.Items;

public class Item : ChangeEvent
{
    // Für EF Core
    private Item() { }

    public Item(
        Entity entity,
        int stateId,
        int priorityId,
        int categoryId,
        string title)
    {
        Entity = entity ?? throw new ArgumentNullException(nameof(entity));

        StateId = stateId;
        PriorityId = priorityId;
        CategoryId = categoryId;
        Title = title ?? throw new ArgumentNullException(nameof(title));
    }
    // Member
    public Guid EntityId { get; set; }
    public int StateId { get; private set; }
    public int PriorityId { get; private set; }
    public int CategoryId { get; private set; }
    public string Title { get; private set; }
    
    // Modelle
    public Entity Entity { get; private set; }
    public State State { get; private set; }
    public Priority Priority { get; private set; }
    public Category Category { get; private set; }

    public bool HasActiveSession 
        => State.Id == (int)Dictionaries.Items.ItemStates.Active;
    public bool CanStartSession
        => State.Id is (int)Dictionaries.Items.ItemStates.Draft
           or (int)Dictionaries.Items.ItemStates.Open
           or (int)Dictionaries.Items.ItemStates.Paused;

    public void ChangeState(int newValue, string? reason = null)
    {
        if (StateId == newValue)
            return;
        AddDomainEvent(new PropertyChangedEvent(
            EntityId: EntityId,
            ActionType: (int)ActionTypes.State,
            OldValue: StateId.ToString(),
            NewValue: newValue.ToString(),
            Reason: reason
        ));
        StateId = newValue;
    }
    public void StartSession() => ChangeState((int)Dictionaries.Items.ItemStates.Active);
    public void PauseSession() => ChangeState((int)Dictionaries.Items.ItemStates.Paused);
    public void ChangePriority(int newValue, string? reason = null)
    {
        if (PriorityId == newValue)
            return;
        AddDomainEvent(new PropertyChangedEvent(
            EntityId: EntityId,
            ActionType: (int)ActionTypes.Priority,
            OldValue: Priority.ToString(),
            NewValue: newValue.ToString(),
            Reason: reason
        ));
        PriorityId = newValue;
    }
    public void ChangeCategory(int newValue, string? reason = null)
    {
        if (CategoryId == newValue)
            return;
        AddDomainEvent(new PropertyChangedEvent(
            EntityId: EntityId,
            ActionType: (int)ActionTypes.Category,
            OldValue: Category.ToString(),
            NewValue: newValue.ToString(),
            Reason: reason
        ));
        CategoryId = newValue;
    }
    public void Rename(string newTitle, string? reason = null)
    {
        if (Title == newTitle || string.IsNullOrWhiteSpace(newTitle))
        {
            return;
        }

        newTitle = newTitle.Trim();
        
        AddDomainEvent(new PropertyChangedEvent(
            EntityId: EntityId,
            ActionType: (int)ActionTypes.Title,
            OldValue: Title,
            NewValue: newTitle,
            Reason: reason
        ));
        Title = newTitle;
    }
}