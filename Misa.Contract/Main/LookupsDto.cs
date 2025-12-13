using Misa.Contract.Audit.Lookups;
using Misa.Contract.Items.Lookups;

namespace Misa.Contract.Main;

public class LookupsDto
{
    public List<StateDto> States { get; set; }
    public List<PriorityDto> Priorities { get; set; }
    public List<CategoryDto> TaskCategories { get; set; }
    public List<SessionEfficiencyTypeDto> EfficiencyTypes { get; set; }
    public List<SessionConcentrationTypeDto> ConcentrationTypes { get; set; }
}