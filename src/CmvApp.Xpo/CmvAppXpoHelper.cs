using System;
using CmvApp.Products;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;

namespace CmvApp.Xpo;

public class CmvAppXpoHelper
{
    private static readonly Type[] entityTypes = new Type[]
    {
        typeof(XPObject),
        typeof(Product)
    };

    public static void InitXpo(string connectionString)
    {
        XpoDefault.DataLayer = CreatePooledDataLayer(connectionString);
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