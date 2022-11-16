using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace CmvApp.Auditing;

[Serializable]
public abstract class CmvCreationAuditedAggregateRoot : AggregateRoot, ICreationAuditedObject
{
    public virtual DateTime CreationTime { get; protected set; }

    public virtual Guid? CreatorId { get; protected set; }
}

[Serializable]
public abstract class CmvCreationAuditedAggregateRoot<TKey> : AggregateRoot<TKey>, ICreationAuditedObject
{
    public virtual DateTime CreationTime { get; set; }

    public virtual Guid? CreatorId { get; set; }

    protected CmvCreationAuditedAggregateRoot()
    {

    }

    protected CmvCreationAuditedAggregateRoot(TKey id)
        : base(id)
    {

    }
}
