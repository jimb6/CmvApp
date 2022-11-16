using CmvApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CmvApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CmvAppController : AbpControllerBase
{
    protected CmvAppController()
    {
        LocalizationResource = typeof(CmvAppResource);
    }
}
