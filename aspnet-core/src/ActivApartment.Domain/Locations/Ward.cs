#nullable enable
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace ActivApartment.Locations;

[Table("ward")]
public class Ward : FullAuditedAggregateRoot<long>
{
    public string  WardName   { get; set; } = string.Empty;
    public string? WardCode   { get; set; }
    public long    DistrictId { get; set; }
}