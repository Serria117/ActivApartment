#nullable enable
using Volo.Abp.Settings;

namespace ActivApartment.Settings;

public class ActivApartmentSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ActivApartmentSettings.MySetting1));
    }
}
