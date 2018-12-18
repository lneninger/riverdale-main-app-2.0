using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RiverdaleMainApp2_0.IoC
{
    /// <summary>
    /// 
    /// </summary>
    public static class AutoFacExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterSignalRHubs(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            // typeof(Hub), not typeof(IHub)
            return builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(Hub).IsAssignableFrom(t))
                .ExternallyOwned();
        }
    }
}
