using System;
using Volo.Abp.Auditing;

namespace CmvApp.Auditing;

[Serializable]
public abstract class CmvAuditedAggregateRoot : CmvCreationAuditedAggregateRoot, IAuditedObject
{
    public virtual DateTime? LastModificationTime { get; set; }

    public virtual Guid? LastModifierId { get; set; }
}

[Serializable]
public abstract class CmvAuditedAggregateRoot<TKey> : CmvCreationAuditedAggregateRoot<TKey>, IAuditedObject
{
    public virtual DateTime? LastModificationTime { get; set; }

    public virtual Guid? LastModifierId { get; set; }

    protected CmvAuditedAggregateRoot()
    {

    }

    protected CmvAuditedAggregateRoot(TKey id)
        : base(id)
    {

    }
}
