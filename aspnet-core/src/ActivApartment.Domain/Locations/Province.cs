#nullable enable
#nullable enable
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Entities.Auditing;

namespace ActivApartment.Locations;

[Table("province")]
[Index(nameof(ProvinceCode), IsUnique = true)]
public class Province : FullAuditedAggregateRoot<long>
{
    public string  ProvinceName { get; set; } = string.Empty;
    public string? ProvinceCode { get; set; }

    public long CountryId { get; set; } = 1;
}