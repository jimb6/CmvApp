using Volo.Abp.Modularity;

namespace CmvApp;

[DependsOn(
    typeof(CmvAppApplicationModule),
    typeof(CmvAppDomainTestModule)
    )]
public class CmvAppApplicationTestModule : AbpModule
{

}
