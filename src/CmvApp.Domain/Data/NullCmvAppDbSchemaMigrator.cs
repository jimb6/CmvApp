using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CmvApp.Data;

/* This is used if database provider does't define
 * ICmvAppDbSchemaMigrator implementation.
 */
public class NullCmvAppDbSchemaMigrator : ICmvAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
