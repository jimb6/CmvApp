using System;
using System.Collections.Generic;

namespace CmvApp.Xpo;

public class XpoDbContextModel
{
    public IReadOnlyDictionary<Type, IXpoEntityModel> Entities { get; }

    public XpoDbContextModel(IReadOnlyDictionary<Type, IXpoEntityModel> entities)
    {
        Entities = entities;
    }
}