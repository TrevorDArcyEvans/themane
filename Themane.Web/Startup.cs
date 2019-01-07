using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Themane.Web.Authentications;
using Themane.Web.Datastores;
using Themane.Web.Interfaces;
using ZNetCS.AspNetCore.Authentication.Basic;
using ZNetCS.AspNetCore.Authentication.Basic.Events;

namespace Themane.Web
{
  public sealed class Startup
  {
    private IServiceProvider ServiceProvider { get; set; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddSingleton<IBasicAuthentication, BasicAuthentication>();
      services.AddSingleton<IContactDatastore, ContactDatastore>();
      services.AddSingleton<ICompanyDatastore, CompanyDatastore>();
      services.AddSingleton<IUsageDatastore, UsageDatastore>();
      services.AddSingleton<IHash, Hash>();
      services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;

        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services
        .AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services
        .AddAuthentication(BasicAuthenticationDefaults.AuthenticationScheme)
        .AddBasicAuthentication(options =>
        {
          options.Realm = "themane web";
          options.Events = new BasicAuthenticationEvents
          {
            OnValidatePrincipal = context =>
            {
              var auth = ServiceProvider.GetService<IBasicAuthentication>();
              return auth.Authenticate(context);
            }
          };
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      ServiceProvider = app.ApplicationServices;

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseAuthentication();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseMvc(routes =>
      {
        routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
      });
    }
  }
}
