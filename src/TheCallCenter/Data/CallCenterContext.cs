using TheCallCenter.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TheCallCenter.Data
{
  public class CallCenterContext : DbContext
  {
    public CallCenterContext(DbContextOptions<CallCenterContext> options) : base(options)
    {

    }

    public DbSet<Call> Calls { get; set; }
  }
}
