using Misa.Contract.Audit;
using Misa.Contract.Entities;
using Misa.Contract.Items;

namespace Misa.Contract.Main;

public class DetailDto
{
    public required ReadEntityDto Entity { get; set; }
    public required ReadItemDto Item { get; set; }
    
    public List<DescriptionDto>? Descriptions { get; set; }
    public List<ReadRelationDto>? Relations { get; set; }
    public List<SessionDto>? Sessions { get; set; }
    public List<ActionDto>? Actions { get; set; }
}