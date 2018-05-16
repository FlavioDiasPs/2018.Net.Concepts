
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace UsingMemoryCache
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

            //IN MEMORY CACHE
            services.AddMemoryCache();

            //SQL SERVER CACHE
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = Configuration
                    .GetConnectionString("CacheSQLServer");
                options.SchemaName = "dbo";
                options.TableName = "DadosCache";
            });

            //CREATE TABLE dbo.DadosCache
            //(
            //    Id nvarchar(449) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
            //    Value varbinary(MAX) NOT NULL,
            //    ExpiresAtTime datetimeoffset NOT NULL,
            //    SlidingExpirationInSeconds bigint NULL,
            //    AbsoluteExpiration datetimeoffset NULL,
            //    CONSTRAINT pk_Id PRIMARY KEY(Id)
            //)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {          
            app.UseDeveloperExceptionPage();
            app.UseExceptionHandler();
            app.UseMvc();
        }
    }
}
