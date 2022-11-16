using CmvApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CmvApp.Web.Pages;

public abstract class CmvAppPageModel : AbpPageModel
{
    protected CmvAppPageModel()
    {
        LocalizationResourceType = typeof(CmvAppResource);
    }
}
