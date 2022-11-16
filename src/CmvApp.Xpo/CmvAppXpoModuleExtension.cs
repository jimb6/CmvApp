using DevExpress.Xpo;
using Microsoft.Extensions.DependencyInjection;

namespace CmvApp.Xpo;

public static class CmvAppXpoModuleExtension
{
    public static IServiceCollection AddXpoPooledDataLayer(this IServiceCollection serviceCollection, string connectionString) {
        return serviceCollection.AddSingleton<IDataLayer>(CmvAppXpoHelper.CreatePooledDataLayer(connectionString));
    }
    public static IServiceCollection AddXpoDefaultUnitOfWork(this IServiceCollection serviceCollection) {
        return serviceCollection.AddScoped<UnitOfWork>((sp) => new UnitOfWork());
    }
    public static IServiceCollection AddXpoUnitOfWork(this IServiceCollection serviceCollection) {
        return serviceCollection.AddScoped<UnitOfWork>((sp) => new UnitOfWork(sp.GetService<IDataLayer>()));
    }
}