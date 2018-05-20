using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FacebookLogin
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
            //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores();
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //            .AddCookie(o => o.LoginPath = new PathString("/login"))
            //            .AddFacebook(o =>
            //            {
            //                o.AppId = Configuration["facebook:appid"];
            //                o.AppSecret = Configuration["facebook:appsecret"];
            //            });


            services.AddAuthentication()                        
                        .AddFacebook(o =>
                        {                         
                            o.AppId = "1049863805164825";
                            o.AppSecret = "1cef1bb4d09e4bc9776d82aff991b95b";
                        });    

            services.AddMvc();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
