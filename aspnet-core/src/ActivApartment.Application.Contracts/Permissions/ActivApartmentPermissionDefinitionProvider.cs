using ActivApartment.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ActivApartment.Permissions;

public class ActivApartmentPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ActivApartmentPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ActivApartmentPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ActivApartmentResource>(name);
    }
}
