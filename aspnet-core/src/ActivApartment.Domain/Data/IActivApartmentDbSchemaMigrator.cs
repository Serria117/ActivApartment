#nullable enable
using System.Threading.Tasks;

namespace ActivApartment.Data;

public interface IActivApartmentDbSchemaMigrator
{
    Task MigrateAsync();
}
