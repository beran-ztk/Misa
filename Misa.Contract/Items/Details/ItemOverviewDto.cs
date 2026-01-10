using Misa.Contract.Entities;
using Misa.Contract.Entities.Features;
using Misa.Contract.Items.Common;

namespace Misa.Contract.Items.Details;

public class ItemOverviewDto
{
    public EntityResolvedDto Entity { get; set; }
    public ItemResolvedDto Item { get; set; }
    public ICollection<DescriptionDto> Descriptions { get; set; }
}