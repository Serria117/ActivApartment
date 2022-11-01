#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ActivApartment.DomainEntities.Building;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ActivApartment.DomainEntities.Room;

[Table("room")]
public class RoomEntity : FullAuditedAggregateRoot<long>, IMultiTenant
{
    [Required, MinLength(3), MaxLength(100)]
    public string RoomNumber { get; set; } = string.Empty;

    [Required, Range(0, 999999999, ErrorMessage = "Price out of range")]
    public decimal BasicPrice { get; set; }

    public string? Description { get; set; }
    public float?  RoomArea    { get; set; }

    public bool      IsAvailable     { get; set; } = true;
    public DateTime  LastCheckInDate { get; set; }
    public DateTime? CheckOutDate    { get; set; }

    //Discount:
    public bool      IsDiscount    { get; set; } = false;
    public DateTime? DiscountFrom  { get; set; }
    public DateTime? DiscountTo    { get; set; }
    public decimal?  DiscountRatio { get; set; }

    public virtual BuildingEntity Building { get; set; } = new();
    public         Guid?          TenantId { get; }
}