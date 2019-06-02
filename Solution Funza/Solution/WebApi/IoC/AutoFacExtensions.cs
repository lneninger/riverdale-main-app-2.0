using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApi.IoC
{
    public static class AutoFacExtensions
    {
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterSignalRHubs(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            return builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(Hub).IsAssignableFrom(t))
                .ExternallyOwned();
        }
    }
}
