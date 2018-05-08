using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace UsingCookie
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("FiverSecurityScheme")
                    .AddCookie("FiverSecurityScheme", options =>
                    {
                        options.AccessDeniedPath = new PathString("/Security/Access");
                        options.Cookie = new CookieBuilder
                        {
                            //Domain = "",
                            HttpOnly = true,
                            Name = ".Fiver.Security.Cookie",
                            Path = "/",
                            SameSite = SameSiteMode.Lax,
                            SecurePolicy = CookieSecurePolicy.SameAsRequest
                        };
                        options.Events = new CookieAuthenticationEvents
                        {
                            OnSignedIn = context =>
                            {
                                Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                                  "OnSignedIn", context.Principal.Identity.Name);
                                return Task.CompletedTask;
                            },
                            OnSigningOut = context =>
                            {
                                Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                                  "OnSigningOut", context.HttpContext.User.Identity.Name);
                                return Task.CompletedTask;
                            },
                            OnValidatePrincipal = context =>
                            {
                                Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                                  "OnValidatePrincipal", context.Principal.Identity.Name);
                                return Task.CompletedTask;
                            }
                        };
                        //options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                        options.LoginPath = new PathString("/Security/Login");
                        options.ReturnUrlParameter = "RequestPath";
                        options.SlidingExpiration = true;
                    });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}
