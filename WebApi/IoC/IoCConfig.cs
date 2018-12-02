using Autofac;
using Framework.Commons;
using Framework.Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Business.Commands.Customer.GetAllCommand;
using ApplicationLogic.Business.Commons;
using RiverdaleMainApp2_0.Auth;
using DomainDatabaseMapping;
using DatabaseRepositories.DB;

namespace RiverdaleMainApp2_0.IoC
{
    /// <summary>
    /// IoC Containner configuration
    /// </summary>
    public class IoCConfig
    {
        /// <summary>
        /// Initializes the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static AutofacServiceProvider Init(Microsoft.Extensions.Configuration.IConfiguration configuration, IServiceCollection services)
        {
            var container = IoCGlobal.Config(builder =>
            {
                builder.Populate(services);


                builder.RegisterType<AppConfig>().AsSelf().WithParameter(new TypedParameter(typeof(IConfiguration), configuration))
                .SingleInstance();


                builder.RegisterType<DbContextScopeFactory>().As<IDbContextScopeFactory>()
                .AsImplementedInterfaces();

                builder.RegisterType<AmbientDbContextLocator>().As<IAmbientDbContextLocator>()
                .AsImplementedInterfaces();


                builder.RegisterType<IdentityDBContext>().AsSelf()
                .TrackInstanceEvents();

                builder.RegisterType<RiverdaleDBContext>().AsSelf()
                .TrackInstanceEvents();

                




                var targetAssembly = Assembly.GetExecutingAssembly();

                var controllerTypes = targetAssembly.GetTypes().Where(type => type.IsClass && type.Name.EndsWith("Controller", StringComparison.InvariantCultureIgnoreCase));
                builder.RegisterTypes(controllerTypes.ToArray())
               .AsSelf();

                var serviceAssembly = typeof(CustomerGetAllCommand).Assembly;
                var serviceTypes = serviceAssembly.GetTypes().Where(type => type.IsClass && type.Name.EndsWith("Command", StringComparison.InvariantCultureIgnoreCase));
                builder.RegisterTypes(serviceTypes.ToArray())
                .AsImplementedInterfaces()
                .TrackInstanceEvents();

                var dataProviderAssembly = typeof(MasterDataProvider).Assembly;
                var dataProviderTypes = serviceAssembly.GetTypes().Where(type => type.IsClass && type.Name.EndsWith("DataProvider", StringComparison.InvariantCultureIgnoreCase));
                builder.RegisterTypes(dataProviderTypes.ToArray())
                .AsImplementedInterfaces()
                .TrackInstanceEvents();

                var repositoryAssembly = typeof(CustomerDBRepository).Assembly;
                var repositoryTypes = repositoryAssembly.GetTypes().Where(type => type.IsClass && type.Name.EndsWith("Repository", StringComparison.InvariantCultureIgnoreCase));
                builder.RegisterTypes(repositoryTypes.ToArray())
                .AsImplementedInterfaces()
                .TrackInstanceEvents();

                // Authentication
                builder
                .RegisterType<JwtFactory>()
                .As<IJwtFactory>()
                .TrackInstanceEvents();

                //var firebaseAssembly = typeof(BaseRepository).Assembly;
                //var firebaseRepositoryTypes = firebaseAssembly.GetTypes().Where(type => type.IsClass && type.Name.EndsWith("Repository", StringComparison.InvariantCultureIgnoreCase));
                //builder.RegisterTypes(firebaseRepositoryTypes.ToArray())
                //.AsImplementedInterfaces()
                //.TrackInstanceEvents();
            });

            return new AutofacServiceProvider(container);
        }
    }
}
