using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ActivApartment;

[Dependency(ReplaceServices = true)]
public class ActivApartmentBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ActivApartment";
}
