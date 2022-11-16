using CmvApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CmvApp;

[DependsOn(
    typeof(CmvAppEntityFrameworkCoreTestModule)
    )]
public class CmvAppDomainTestModule : AbpModule
{

}
