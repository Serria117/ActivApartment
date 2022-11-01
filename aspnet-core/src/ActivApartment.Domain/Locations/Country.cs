#nullable enable
#nullable enable
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Entities.Auditing;

namespace ActivApartment.Locations;
[Table("country")]
[Index(
    nameof(Code), nameof(CountryName), 
    IsUnique = true)
]
public class Country: FullAuditedAggregateRoot<long>
{
    public string CountryName { get; set; } = string.Empty;
    public string Code        { get; set; } = string.Empty;
}