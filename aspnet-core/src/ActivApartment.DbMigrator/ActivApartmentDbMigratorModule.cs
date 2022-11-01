using ActivApartment.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ActivApartment.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ActivApartmentEntityFrameworkCoreModule),
    typeof(ActivApartmentApplicationContractsModule)
    )]
public class ActivApartmentDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
