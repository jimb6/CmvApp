using System;
using JetBrains.Annotations;

namespace CmvApp.Xpo;

public interface IXpoModelBuilder
{
    void Entity<TEntity>(Action<IXpoEntityModelBuilder<TEntity>> buildAction = null);

    void Entity([NotNull] Type entityType, Action<IXpoEntityModelBuilder> buildAction = null);
}