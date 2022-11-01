#nullable enable
using ActivApartment.Dto;
using Volo.Abp.Application.Dtos;

namespace ActivApartment.IBuilding.Dto;

public class InputBuildingDto : SearchDto, IPagedResultRequest
{
    public int     MaxResultCount { get; set; }
    public int     SkipCount      { get; set; }
}