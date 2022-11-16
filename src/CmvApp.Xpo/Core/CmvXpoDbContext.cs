using DevExpress.Xpo;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace CmvApp.Xpo;

public abstract class CmvXpoDbContext : Session
{
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; }
    public Session SessionHandle { get; private set; }

    protected internal virtual void CreateModel(IXpoModelBuilder modelBuilder)
    {
        
    }

    public virtual void InitializeDatabase(Session sessionHandle)
    {
        SessionHandle = sessionHandle;
    }
    
    protected virtual IXpoEntityModel GetEntityModel<TEntity>()
    {
        // var model = ModelSource.GetModel(this).Entities.GetOrDefault(typeof(TEntity));
        //
        // if (model == null)
        // {
        //     throw new AbpException("Could not find a model for given entity type: " + typeof(TEntity).AssemblyQualifiedName);
        // }

        return null;
    }

}