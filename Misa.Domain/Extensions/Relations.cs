using Misa.Domain.Dictionaries;

namespace Misa.Domain.Extensions;

public class Relations
{
    private Relations() { }
    public Relations(Guid parentId, Guid childId)
    {
        ParentId = parentId;
        ChildId = childId;
    }
    public Relations(Guid entityId, Guid parentId, Guid childId)
    {
        EntityId = entityId;
        ParentId = parentId;
        ChildId = childId;
    }
    public Guid EntityId { get; private set; }
    public Guid ParentId { get; private set; }
    public Guid ChildId { get; private set; }
    public int RelationId { get; private set; }

    public void SetRelation(RelationTypeDictionary relationType)
        => RelationId = (int)relationType;
}