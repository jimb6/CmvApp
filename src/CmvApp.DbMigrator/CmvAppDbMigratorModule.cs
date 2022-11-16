using CmvApp.EntityFrameworkCore;
using CmvApp.Xpo;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CmvApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CmvAppEntityFrameworkCoreModule),
    typeof(CmvAppApplicationContractsModule)
)]
public class CmvAppDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = false;
        });
    }
}
