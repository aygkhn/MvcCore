using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreMvc.Identity;
using FirstCoreMvc.Model;
using FirstCoreMvc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstCoreMvc
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<SchoolContext>(options=>options.UseSqlServer(_configuration["DbConnection"]));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(_configuration["DbConnection"]));
            services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(option=> 
            {
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = true;
                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);

            });

            services.ConfigureApplicationCookie(options=> {
                options.LoginPath = "/Security/Login";
                options.LogoutPath = "/Security/Logout";
                options.AccessDeniedPath = "/Security/AccessDenied";
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name=".Asp",
                    Path="/",
                    SameSite=SameSiteMode.Lax,
                    SecurePolicy=CookieSecurePolicy.SameAsRequest
                };
            });

            services.AddScoped<ICalculator,Calculator8>();
            services.AddSession();
            services.AddDistributedMemoryCache();
            //services.AddSingleton
           // services.AddTransient
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseSession(new SessionOptions {});
            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder route)
        {
            //Conventional Routing (Geleneksel)
            route.MapRoute("default","{controller=Home}/{action=Index}/{id?}");
            route.MapRoute("MyRoute", "Engin/{controller=Home}/{action=Index}/{id?}");

                route.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
        }
    }
}
