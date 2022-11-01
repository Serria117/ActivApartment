#nullable enable
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace ActivApartment.DomainEntities.Building;

[Table("building_type")]
public class BuildingType : FullAuditedAggregateRoot<long>
{
    public string  Type        { get; set; } = string.Empty;
    public string? Description { get; set; }
}