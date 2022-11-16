using DevExpress.Xpo;

namespace CmvApp.Xpo;

public interface IXpoDbContext
{
    Session SessionHandle { get; }
 }