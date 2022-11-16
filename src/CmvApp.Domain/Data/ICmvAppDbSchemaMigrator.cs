using System.Threading.Tasks;

namespace CmvApp.Data;

public interface ICmvAppDbSchemaMigrator
{
    Task MigrateAsync();
}
