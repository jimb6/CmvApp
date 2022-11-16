using Microsoft.EntityFrameworkCore;

namespace CmvApp.EntityFrameworkCore;

public class CmvAppXpoDbContext : CmvAppDbContext<CmvAppXpoDbContext>
{
    public CmvAppXpoDbContext(DbContextOptions<CmvAppXpoDbContext> options) : base(options)
    { }
}