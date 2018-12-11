using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreMvc.Model;
using FirstCoreMvc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FirstCoreMvc
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = @"Server=GOKHANAY;Database=SchoolDb;uid=sa;password=1";
            services.AddDbContext<SchoolContext>(options=>options.UseSqlServer(connection));
            services.AddScoped<ICalculator,Calculator8>();
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

            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder route)
        {
            //Conventional Routing (Geleneksel)
            route.MapRoute("default","{controller=Home}/{action=Index}/{id?}");
            route.MapRoute("MyRoute", "Engin/{controller=Home}/{action=Index}/{id?}");
        }
    }
}
