using Autofac.Extensions.DependencyInjection;
using DomainDatabaseMapping;
using Framework.Logging.Log4Net;
using Framework.Refit;
using Framework.Storage.FileStorage.TemporaryStorage;
using FunzaCommons;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using WebApi.ErrorHandling;
using WebApi.IoC;
using WebApi.SignalR;

namespace WebApi
{
    public class Startup
    {
        static LoggerCustom Logger = Framework.Logging.Log4Net.LoggerFactory.Create(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Startup(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            Configuration = configuration;
            ServiceProvider = serviceProvider;

            this.ConnectionString = Configuration.GetConnectionString("RiverdaleModel");
            Logger.Info($"Main Database Connection - FunzaModel: {this.ConnectionString}");
        }

        public IConfiguration Configuration { get; }
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Global Connection String
        /// </summary>
        public string ConnectionString { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //var logger = Framework.Logging.Log4Net.LoggerFactory.Create(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Logger.Info("Application startup - Initializing the Infra Services Configuration");
            try
            {

                //services.Configure<CookiePolicyOptions>(options =>
                //{
                //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                //    options.CheckConsentNeeded = context => true;
                //    options.MinimumSameSitePolicy = SameSiteMode.None;
                //});

                var customSettings = this.Configuration.GetSection("CustomSettings").Get<CustomSettings>();
                Logger.Info($"Application startup - Allowed origins: {string.Join(",", customSettings.AllowedOrigins)}");

                services.AddCors();

                services.AddAutofac();


                services.AddSignalR(config =>
                {
                    config.EnableDetailedErrors = true;
                });

                services.AddDbContext<FunzaDBContext>(options => options.UseSqlServer(this.ConnectionString));


                services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

                services.AddApiVersioning(o =>
                {
                    o.AssumeDefaultVersionWhenUnspecified = true;
                    o.DefaultApiVersion = new ApiVersion(new DateTime(2016, 7, 1));
                });

                SwaggerConfig.EnableServiceSwaggerMiddleware(services);

                services.AddOptions();


                RefitConfig.Configure(this.Configuration, services, ServiceProvider);

                var autofacServiceProvider = IoCConfig.Init(Configuration, services);

                return autofacServiceProvider;

            }
            catch (Exception ex)
            {
                Logger.Fatal("Application startup - Execption on Infra Services Configuration", ex);
                throw;
            }
            finally
            {
                Logger.Info("Application startup - Ending the Infra Services Configuration");
                Logger.FlushBuffers();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            try
            {
                Logger.Info("Application startup - Initializing the Infra Application Configuration");

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseHsts();
                }

                app.ConfigureExceptionHandler();

                SwaggerConfig.ConfigureApplicationSwaggerMiddleware(app);

                //app.UseElmah();

                // Shows UseCors with CorsPolicyBuilder.
                //app.UseCors("Development");
                app.UseCors(builder => builder
                   .AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials()
                );

                app.UseSignalR(routes =>
                {
                    routes.MapHub<GlobalHub>("/globalhub", configureOptions =>
                    {
                    });
                });

                app.UseTempFileMiddleware();

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseAuthentication();
                app.UseMvc();
            }
            catch (Exception ex)
            {
                Logger.Fatal("Application startup - Execption on Infra Application Configuration", ex);
            }
            finally
            {
                Logger.Info("Application startup - Ending the Infra Application Configuration");
                Logger.FlushBuffers();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
