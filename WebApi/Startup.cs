using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainDatabaseMapping;
using FocusAIRemote.IoC;
using Framework.Autofac;
using Framework.Storage.FileStorage.TemporaryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FocusAIRemote
{
    /// <summary>
    /// Application Setup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this.ConnectionString = Configuration.GetConnectionString("RiverdaleModel");

        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; }

        // This method gets called by the runtime. Use this method to add services to the container.        
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.AddDbContext<RiverdaleDBContext>(options => options.UseSqlServer(this.ConnectionString));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(builder =>
            {
               
                //options.AddPolicy("AllowSpecificOrigin",
                //    builder => builder.WithOrigins("http://example.com"));
            });

            return IoCConfig.Init(Configuration, services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.        
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
               builder
               .WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod()
           );


             app.UseTempFileMiddleware();

            app.UseStaticFiles();
            //app.UseCookiePolicy();

            app.UseMvc();

        }
    }
}
