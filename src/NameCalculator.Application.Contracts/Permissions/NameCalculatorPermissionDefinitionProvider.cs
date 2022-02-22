using NameCalculator.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NameCalculator.Permissions;

public class NameCalculatorPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NameCalculatorPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(NameCalculatorPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NameCalculatorResource>(name);
    }
}
