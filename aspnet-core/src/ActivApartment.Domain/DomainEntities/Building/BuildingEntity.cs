#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ActivApartment.DomainEntities.Room;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ActivApartment.DomainEntities.Building;

[Table("building")]
public class BuildingEntity : FullAuditedAggregateRoot<long>, IMultiTenant
{
    public string BuildingName    { get; set; } = string.Empty;
    public string ShortName       { get; set; } = string.Empty;
    public string BuildingAddress { get; set; } = string.Empty;

    public long BuildingTypeId { get; set; }

    public long  CountryId  { get; set; }
    public long  ProvinceId { get; set; }
    public long  DistrictId { get; set; }
    public long  WardId     { get; set; }
    public Guid? TenantId   { get; set; }

    public bool IsActivated { get; set; } = true;

    public ICollection<RoomEntity> RoomEntities { get; set; } = new List<RoomEntity>();
}