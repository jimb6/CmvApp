using System;
using System.Collections.Concurrent;
using CmvApp.Products;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CmvApp.Xpo;



[ConnectionStringName("Default")]
public class CmvAppDbContext : AbpDbContext<CmvAppDbContext>
{
    private static readonly Type[] entityTypes = {
        typeof(XPObject),
        typeof(Product)
    };
    
    public CmvAppDbContext(DbContextOptions<CmvAppDbContext> options) : base(options)
    {
        
    }

    private ConcurrentDictionary<Type, bool> set_dic = new();
    private static object locks = new();
    public override void Initialize(AbpEfCoreDbContextInitializationContext initializationContext)
    {
        XpoDefault.DataLayer = CreatePooledDataLayer(connectionString: "Server=(LocalDb)\\MSSQLLocalDB;Database=CMVPoint_App;Trusted_Connection=True");
        XpoDefault.Session = null;
    }

    public static ThreadSafeDataLayer CreatePooledDataLayer(string connectionString)
    {
        var dictionary = PrepareDictionary();
        using (var updateDataLayer = XpoDefault.GetDataLayer(connectionString, dictionary, AutoCreateOption.DatabaseAndSchema))
        {
            updateDataLayer.UpdateSchema(false, dictionary.CollectClassInfos(entityTypes));
        }

        string pooledConnectionString = XpoDefault.GetConnectionPoolString(connectionString);
        var dataStore = XpoDefault.GetConnectionProvider(pooledConnectionString, AutoCreateOption.SchemaAlreadyExists);
        var dataLayer = new ThreadSafeDataLayer(dictionary, dataStore);
        return dataLayer;
    }

    public static XPDictionary PrepareDictionary()
    {
        var dict = new ReflectionDictionary();
        dict.GetDataStoreSchema(entityTypes);
        return dict;
    }
}