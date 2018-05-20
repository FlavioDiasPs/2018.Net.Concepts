using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CreatingMiddleware
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

            //app.Use(async (HttpContext context, Func<Task> next) =>
            //{
            //    //do work before the invoking the rest of the pipeline       

            //    await next.Invoke(); //let the rest of the pipeline run

            //    //do work after the rest of the pipeline has run     
            //});

            app.UseMiddleware<MyFileLoggerMiddleware>(Options.Create(new MyFileLoggerOptions
            {
                fileUrl = System.IO.Path.Combine(env.ContentRootPath, "logFile.txt")
            }));

            app.UseMyFileLogger(new MyFileLoggerOptions
            {
                fileUrl = System.IO.Path.Combine(env.ContentRootPath, "log.txt")
            });


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
