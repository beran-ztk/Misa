namespace Misa.Contract.Audit.Lookups;

public class SessionConcentrationTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Synopsis { get; set; }
    public int SortOrder { get; set; }
}