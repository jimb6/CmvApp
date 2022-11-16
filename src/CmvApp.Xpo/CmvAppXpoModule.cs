using DevExpress.Xpo.DB;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace CmvApp.Xpo;

public class CmvAppXpoModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var server = "(LocalDb)\\MSSQLLocalDB";
        var database = "CMVPoint_App";
        
        context.Services
            .AddXpoPooledDataLayer(MSSqlConnectionProvider.GetConnectionString(server: server, database: database))
            .AddXpoUnitOfWork();

        Configure<AbpUnitOfWorkDefaultOptions>(options =>
        {
            options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
        });
    }
}