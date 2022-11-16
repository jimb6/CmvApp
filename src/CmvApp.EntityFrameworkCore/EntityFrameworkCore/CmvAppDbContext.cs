using System;
using CmvApp.Products;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict.EntityFrameworkCore;

namespace CmvApp.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityProDbContext))]
[ReplaceDbContext(typeof(ISaasDbContext))]
[ConnectionStringName("Default")]
public class CmvAppDbContext<TDbContext> : AbpDbContext<TDbContext> where TDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    
    private static readonly Type[] entityTypes = new Type[]
    {
        typeof(XPObject),
        typeof(Product)
    };
    
    // public DbSet<Product> Products { get; set; }
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    // #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    // public DbSet<IdentityUser> Users { get; set; }
    // public DbSet<IdentityRole> Roles { get; set; }
    // public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    // public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    // public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    // public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // SaaS
    // public DbSet<Tenant> Tenants { get; set; }
    // public DbSet<Edition> Editions { get; set; }
    // public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    // #endregion

    public CmvAppDbContext(DbContextOptions<TDbContext> options)
        : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     base.OnModelCreating(builder);
    //
    //     /* Include modules to your migration db context */
    //
    //     // builder.ConfigurePermissionManagement();
    //     // builder.ConfigureSettingManagement();
    //     // builder.ConfigureBackgroundJobs();
    //     // builder.ConfigureAuditLogging();
    //     // builder.ConfigureIdentityPro();
    //     // builder.ConfigureOpenIddict();
    //     // builder.ConfigureFeatureManagement();
    //     // builder.ConfigureLanguageManagement();
    //     // builder.ConfigureSaas();
    //     // builder.ConfigureTextTemplateManagement();
    //     // builder.ConfigureBlobStoring();
    //     // builder.ConfigureGdpr();
    //
    //     /* Configure your own tables/entities inside here */
    //
    //     //builder.Entity<YourEntity>(b =>
    //     //{
    //     //    b.ToTable(CmvAppConsts.DbTablePrefix + "YourEntities", CmvAppConsts.DbSchema);
    //     //    b.ConfigureByConvention(); //auto configure for the base class props
    //     //    //...
    //     //});
    //     // if (builder.IsHostDatabase())
    //     // {
    //     //     builder.Entity<Product>(b =>
    //     //     {
    //     //         b.ToTable(CmvAppConsts.DbTablePrefix + "Products", CmvAppConsts.DbSchema);
    //     //         b.ConfigureByConvention();
    //     //         b.Property(x => x.Name).HasColumnName(nameof(Product.Name)).IsRequired();
    //     //         b.Property(x => x.Description).HasColumnName(nameof(Product.Description)).IsRequired();
    //     //         b.Property(x => x.Price).HasColumnName(nameof(Product.Price));
    //     //     });
    //     // }
    // }

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