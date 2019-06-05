using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApi
{
    /// <summary>
    /// Swagger Documentation config
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Configures the application swagger middleware.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void ConfigureApplicationSwaggerMiddleware(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "RiverdaleAPI V1.0");
            });
        }

        /// <summary>
        /// Enables the service swagger middleware.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void EnableServiceSwaggerMiddleware(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info { Title = "RiverdaleAPI", Version = "1.0" });

                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);


                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });
            });
        }
    }
}
