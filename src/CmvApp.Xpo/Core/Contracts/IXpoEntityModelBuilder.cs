using System;

namespace CmvApp.Xpo;

public interface IXpoEntityModelBuilder<TEntity>
{
    Type EntityType { get; }

    string CollectionName { get; set; }

    // BsonClassMap<TEntity> BsonMap { get; }
}

public interface IXpoEntityModelBuilder
{
    Type EntityType { get; }

    string CollectionName { get; set; }

    // BsonClassMap<TEntity> BsonMap { get; }
}