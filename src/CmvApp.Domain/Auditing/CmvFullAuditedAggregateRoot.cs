using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace CmvApp.Auditing;


[Serializable]
public abstract class CmvFullAuditedAggregateRoot : CmvAuditedAggregateRoot, IFullAuditedObject
{
    
    public virtual bool IsDeleted { get; set; }
    
    public virtual Guid? DeleterId { get; set; }

    public virtual DateTime? DeletionTime { get; set; }
}

[Serializable]
public abstract class CmvFullAuditedAggregateRoot<TKey> : CmvAuditedAggregateRoot<TKey>, IFullAuditedObject
{
    public virtual bool IsDeleted { get; set; }
    
    public virtual Guid? DeleterId { get; set; }
    
    public virtual DateTime? DeletionTime { get; set; }

    protected CmvFullAuditedAggregateRoot()
    {

    }

    protected CmvFullAuditedAggregateRoot(TKey id)
        : base(id)
    {

    }
}
