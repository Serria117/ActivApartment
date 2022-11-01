using ActivApartment.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ActivApartment;

[DependsOn(
    typeof(ActivApartmentEntityFrameworkCoreTestModule)
    )]
public class ActivApartmentDomainTestModule : AbpModule
{

}
