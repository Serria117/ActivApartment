#nullable enable
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ActivApartment.Data;

/* This is used if database provider does't define
 * IActivApartmentDbSchemaMigrator implementation.
 */
public class NullActivApartmentDbSchemaMigrator : IActivApartmentDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
