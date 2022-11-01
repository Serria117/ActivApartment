using System;
using System.Linq;
using System.Threading.Tasks;
using ActivApartment.DomainEntities.Building;
using ActivApartment.IBuilding;
using ActivApartment.IBuilding.Dto;
using ActivApartment.Locations;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace ActivApartment.BuildingService;

public class BuildingService : ActivApartmentAppService, IBuildingService
{
    private readonly IRepository<BuildingEntity, long> _buidingRepo;
    private readonly IRepository<Country, long>        _countryRepo;
    private readonly IRepository<Province, long>       _provinceRepo;
    private readonly IRepository<District, long>       _districtRepo;
    private readonly IRepository<Ward, long>           _wardRepo;
    private readonly IRepository<BuildingType, long>   _buidingTypeRepo;
    private readonly ICurrentTenant                    _currentTenant;

    public BuildingService(IRepository<BuildingEntity, long> buidingRepo,
                           ICurrentTenant currentTenant,
                           IRepository<Province, long> provinceRepo,
                           IRepository<Country, long> countryRepo,
                           IRepository<District, long> districtRepo,
                           IRepository<Ward, long> wardRepo,
                           IRepository<BuildingType, long> buidingTypeRepo)
    {
        _buidingRepo     = buidingRepo;
        _currentTenant   = currentTenant;
        _provinceRepo    = provinceRepo;
        _countryRepo     = countryRepo;
        _districtRepo    = districtRepo;
        _wardRepo        = wardRepo;
        _buidingTypeRepo = buidingTypeRepo;
    }

    public async Task CreateBuilding(CreateBuildingDto input)
    {
        try
        {
            await _buidingRepo.InsertAsync(new BuildingEntity()
            {
                BuildingName    = input.BuildingName,
                BuildingAddress = input.BuildingAddress,
                ShortName       = input.ShortName,
                BuildingTypeId  = input.BuildingTypeId,
                CountryId       = input.CountryId ?? 1,
                ProvinceId      = input.ProvinceId,
                DistrictId      = input.DistrictId,
                WardId          = input.WardId,
                TenantId        = _currentTenant.Id,
            }, true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new UserFriendlyException("Operation failed. " + e.Message);
        }
    }

    public async Task<IPagedResult<DisplayBuildingDto>> GetBuildingList(InputBuildingDto input)
    {
        var query =
            from b in (await _buidingRepo.GetQueryableAsync())
                      .Where(x => x.IsActivated == true && x.TenantId == _currentTenant.Id)
                      .WhereIf(!input.Filter.IsNullOrWhiteSpace(),
                          x =>
                              x.BuildingName.Contains(input.Filter.Trim()) ||
                              x.ShortName.Contains(input.Filter.Trim()))
            join c in await _countryRepo.GetQueryableAsync() on b.CountryId equals c.Id
            join p in await _provinceRepo.GetQueryableAsync() on b.ProvinceId equals p.Id
            join d in await _districtRepo.GetQueryableAsync() on b.DistrictId equals d.Id
            join w in await _wardRepo.GetQueryableAsync() on b.WardId equals w.Id
            join t in await _buidingTypeRepo.GetQueryableAsync() on b.BuildingTypeId equals t.Id
            select new DisplayBuildingDto()
            {
                Country         = c.CountryName,
                Province        = p.ProvinceName,
                District        = d.DistrictName,
                Ward            = w.WardName,
                BuildingName    = b.BuildingName,
                BuildingAddress = b.BuildingAddress,
                BuildingType    = t.Type,
                ShortName       = b.ShortName,
                Id              = b.Id
            };
        var count = query.Count();
        var result = query.PageBy(input).ToList();
        return new PagedResultDto<DisplayBuildingDto>(count, result);
    }

    public async Task UpdateBuilding(long id, CreateBuildingDto input)
    {
        try
        {
            var foundBuilding = await _buidingRepo.FirstOrDefaultAsync(x => x.Id == id);
            if (foundBuilding == null)
            {
                throw new EntityNotFoundException("Id does not exist");
            }

            foundBuilding.BuildingName    = input.BuildingName;
            foundBuilding.BuildingAddress = input.BuildingAddress;
            foundBuilding.ShortName       = input.ShortName;
            foundBuilding.CountryId       = input.CountryId ?? foundBuilding.CountryId;
            foundBuilding.ProvinceId      = input.DistrictId;
            foundBuilding.DistrictId      = input.DistrictId;
            foundBuilding.WardId          = input.DistrictId;
            await _buidingRepo.UpdateAsync(foundBuilding);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<object> DeleteBuilding(long id)
    {
        try
        {
            var foundBuilding = await _buidingRepo.FirstOrDefaultAsync(x => x.Id == id);
            if (foundBuilding == null)
            {
                throw new EntityNotFoundException("Id does not exist");
            }

            foundBuilding.IsDeleted   = true;
            foundBuilding.IsActivated = false;
            await _buidingRepo.UpdateAsync(foundBuilding);
            return new { succeed = true, message = "Bulding deleted" };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new { succeed = false, message = e.Message };
        }
    }
}