#nullable enable
using System;
using System.Threading.Tasks;
using ActivApartment.IBuilding.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ActivApartment.IBuilding;

public interface IBuildingService : IApplicationService
{
    Task CreateBuilding(CreateBuildingDto input);
    Task<IPagedResult<DisplayBuildingDto>> GetBuildingList(InputBuildingDto input);
    Task UpdateBuilding(long id, CreateBuildingDto input);
    Task<object> DeleteBuilding(long id);
}