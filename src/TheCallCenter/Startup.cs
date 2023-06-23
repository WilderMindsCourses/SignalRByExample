using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheCallCenter.Data;

namespace TheCallCenter
{
  public class Startup
  {
    private readonly IConfiguration _config;

    public Startup(IConfiguration config)
    {
      _config = config;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<CallCenterContext>()
        .AddEntityFrameworkSqlServer();

      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      /* 
       * 2023-06-12 - Differ from Video: 
       * Replaces AddMvc() with AddControllersWithViews(). 
       * AddMvc Enables Razor Pages when we don't need that feature. Adding
       * Mvc instead of just "ControllersWithViews" adds a performance hit that's
       * unnecessary
       */
      services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();
      app.UseRouting();
      app.UseCookiePolicy();

      app.UseEndpoints(routes =>
      {
        /* 
         * 2023-06-12 - Differ From Video
         * MapHub<T> exists in app.UseEndpoints delegate, NOT in app.UseSignalR delegate anymore.
         */

        routes.MapControllerRoute(
          "default",
          "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
