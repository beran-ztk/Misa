namespace Misa.Domain.Audit;

public class SessionEfficiencyType
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Synopsis { get; private set; }
    public int SortOrder { get; private set; }
}
