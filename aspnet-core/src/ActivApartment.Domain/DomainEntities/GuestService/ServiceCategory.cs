using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

#nullable enable
namespace ActivApartment.DomainEntities.GuestService;

[Table("service_category")]
public class ServiceCategory : Entity<long>
{
    public string  ServiceCategoryName { get; set; } = string.Empty;
    public long?   ServiceParentId     { get; set; }
    public string? TreePath            { get; set; }

    public ICollection<GuestServiceEntity> GuestServiceEntities { get; set; } = new List<GuestServiceEntity>();
}