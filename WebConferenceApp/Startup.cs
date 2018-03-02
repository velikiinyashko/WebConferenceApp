using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebConferenceApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebConferenceApp.Hubs;

namespace WebConferenceApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<BaseContext>(options =>
            options.UseMySql(@"server=db.sibitproject.ru;user=test;password=37k6G1KaKILiDA1EV8Vu1OJiha2ob3;database=TestAppBuild;port=3306"));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/cabinet/home/login");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
            });
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/hubs/chat");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                              name: "areas",
                              template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                              name: "default",
                              template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
