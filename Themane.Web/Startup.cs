using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ZNetCS.AspNetCore.Authentication.Basic;
using ZNetCS.AspNetCore.Authentication.Basic.Events;

namespace Themane.Web
{
  public sealed class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
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
              if (context.UserName == context.Password)
              {
                var claims = new List<Claim>
                {
                  new Claim(ClaimTypes.Name, context.UserName, context.Options.ClaimsIssuer),
                  new Claim(ClaimTypes.Role, context.UserName, context.Options.ClaimsIssuer)
                };

                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, BasicAuthenticationDefaults.AuthenticationScheme));
                context.Principal = principal;
              }
              else
              {
                // optional with following default.
                context.AuthenticationFailMessage = "Authentication failed."; 
              }

              return Task.CompletedTask;
            }
          };
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
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
