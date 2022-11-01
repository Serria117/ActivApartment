using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

#nullable enable
namespace ActivApartment.DomainEntities.GuestService;

[Table("guest_service")]
public class GuestServiceEntity : FullAuditedEntity<long>
{
    public string  ServiceName       { get; set; } = string.Empty;
    public long    ServiceCategoryId { get; set; }
    public string? Description       { get; set; }
    public decimal UnitPrice         { get; set; }
    public string  UnitCount         { get; set; } = string.Empty;
}