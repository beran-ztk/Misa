using Misa.Contract.Entities;
using Misa.Contract.Main;
using Misa.Domain.Entities;
using Misa.Domain.Main;

namespace Misa.Application.Main.Mappings;

public static class DescriptionDtoMapper
{
    public static DescriptionDto ToDto(this Description dto)
        => new DescriptionDto
        {
            Id = dto.Id,
            EntityId = dto.EntityId,
            TypeId = dto.TypeId,
            Content = dto.Content
        };
    public static List<DescriptionDto> ToDto(this ICollection<Description> dto)
        => dto.Select(x => new DescriptionDto
        {
            Id = x.Id,
            EntityId = x.EntityId,
            TypeId = x.TypeId,
            Content = x.Content
        }).ToList();
}