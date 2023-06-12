using TheCallCenter.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TheCallCenter.Data
{
  public class CallCenterContext : DbContext
  {
    private readonly IConfiguration _config;

    public CallCenterContext(DbContextOptions<CallCenterContext> options, IConfiguration config) : base(options)
    {
      _config = config;
    }

    public DbSet<Call> Calls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder bldr)
    {
      bldr.UseSqlServer(_config.GetConnectionString("CallCenterConnectionString"));
    }
  }
}
