using Volo.Abp.Modularity;

namespace ActivApartment;

[DependsOn(
    typeof(ActivApartmentApplicationModule),
    typeof(ActivApartmentDomainTestModule)
    )]
public class ActivApartmentApplicationTestModule : AbpModule
{

}
