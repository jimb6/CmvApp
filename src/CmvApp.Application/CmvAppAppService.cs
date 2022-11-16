using CmvApp.Localization;
using Volo.Abp.Application.Services;

namespace CmvApp;

/* Inherit your application services from this class.
 */
public abstract class CmvAppAppService : ApplicationService
{
    protected CmvAppAppService()
    {
        LocalizationResource = typeof(CmvAppResource);
    }
}
