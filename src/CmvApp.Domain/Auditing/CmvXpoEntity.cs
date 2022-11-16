using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using Volo.Abp.Domain.Entities;

namespace CmvApp.Auditing;

[Serializable]
public abstract class CmvXpoEntity : XPBaseObject, IEntity
{
    protected CmvXpoEntity()
    {
        EntityHelper.TrySetTenantId(this);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}] Keys = {GetKeys().JoinAsString(", ")}";
    }

    public abstract object[] GetKeys();

    public bool EntityEquals(IEntity other)
    {
        return EntityHelper.EntityEquals(this, other);
    }
}

/// <inheritdoc cref="IEntity{TKey}" />
[Serializable]
public abstract class CmvXpoEntity<TKey> : CmvXpoEntity, IEntity<TKey>
{
    /// <inheritdoc/>
    public virtual TKey Id { get; protected set; }

    protected CmvXpoEntity()
    {

    }

    protected CmvXpoEntity(TKey id)
    {
        Id = id;
    }

    public override object[] GetKeys()
    {
        return new object[] { Id };
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}] Id = {Id}";
    }
}
