#nullable enable
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace ActivApartment.Locations;

[Table("district")]
public class District : FullAuditedAggregateRoot<long>
{
    public string  DistrictName { get; set; } = string.Empty;
    public string? DistrictCode { get; set; }
    public long    ProvinceId   { get; set; }
}