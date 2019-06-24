using EntityFrameworkCore.DbContextScope;
using Framework.Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.IoC
{
    public class DbContextFactory : IDbContextFactory
    {
        public DbContextFactory(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; }

        public TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext
        {
            var result = (TDbContext)this.ServiceProvider.GetService(typeof(TDbContext));

            //var result = (TDbContext)IoCGlobal.Resolve(typeof(TDbContext));
            return result;
        }
    }
}
