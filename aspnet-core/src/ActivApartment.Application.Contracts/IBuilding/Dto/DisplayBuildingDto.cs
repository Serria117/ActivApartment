using System;
using Volo.Abp.Application.Dtos;

namespace ActivApartment.IBuilding.Dto;

public class DisplayBuildingDto : IEntityDto<long>
{
    public long   Id              { get; set; }
    public string BuildingName    { get; set; } = string.Empty;
    public string ShortName       { get; set; } = string.Empty;
    public string BuildingAddress { get; set; } = string.Empty;

    public string BuildingType { get; set; }

    public string  Country  { get; set; }
    public string  Province { get; set; }
    public string  District { get; set; }
    public string  Ward     { get; set; }
    public Guid? TenantId   { get; set; }

    public bool IsActivated { get; set; }
}