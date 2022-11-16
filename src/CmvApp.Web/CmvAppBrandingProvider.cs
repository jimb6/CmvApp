using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace CmvApp.Web;

[Dependency(ReplaceServices = true)]
public class CmvAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CmvApp";
}
