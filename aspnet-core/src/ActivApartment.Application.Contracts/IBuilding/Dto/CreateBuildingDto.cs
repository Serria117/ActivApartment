using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ActivApartment.IBuilding.Dto;

public class CreateBuildingDto: EntityDto<long>
{
    [Required, MinLength(3), MaxLength(200)]
    public string BuildingName    { get; set; } = string.Empty;
    [Required, MinLength(3), MaxLength(100)]
    public string ShortName       { get; set; } = string.Empty;
    public string BuildingAddress { get; set; } = string.Empty;

    public int BuildingTypeId { get; set; }

    public long? CountryId  { get; set; }
    public long ProvinceId { get; set; }
    public long DistrictId { get; set; }
    public long WardId     { get; set; }
}