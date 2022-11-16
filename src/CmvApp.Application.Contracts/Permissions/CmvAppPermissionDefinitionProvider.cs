using CmvApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace CmvApp.Permissions;

public class CmvAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CmvAppPermissions.GroupName);

        myGroup.AddPermission(CmvAppPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(CmvAppPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(CmvAppPermissions.MyPermission1, L("Permission:MyPermission1"));

        var productPermission = myGroup.AddPermission(CmvAppPermissions.Products.Default, L("Permission:Products"));
        productPermission.AddChild(CmvAppPermissions.Products.Create, L("Permission:Create"));
        productPermission.AddChild(CmvAppPermissions.Products.Edit, L("Permission:Edit"));
        productPermission.AddChild(CmvAppPermissions.Products.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CmvAppResource>(name);
    }
}