using System;

namespace CmvApp.Xpo;

public interface IXpoEntityModel
{
    Type EntityType { get; }

    string CollectionName { get; }
}