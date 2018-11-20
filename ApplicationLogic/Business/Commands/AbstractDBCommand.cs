using EntityFrameworkCore.DbContextScope;
using FocusApplication.Repositories.DB;
using Framework.Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace FocusServices.Business.Commands
{
    public class AbstractDBCommand<TEntity, TRepository>: BaseIoCDisposable where TEntity: class, new() where TRepository : IDBRepository<TEntity>
    {
        public AbstractDBCommand(IDbContextScopeFactory dbContextScopeFactory, TRepository repository)
        {
            this.DbContextScopeFactory = dbContextScopeFactory;
            this.Repository = repository;
        }

        public IDbContextScopeFactory DbContextScopeFactory { get; }
        public TRepository Repository { get; }




        protected override void Dispose(bool disposing)
        {
            //ReleaseBuffer(buffer); // release unmanaged memory  
            if (disposing)
            { // release other disposable objects  
                IoCGlobal.MarkInstanceForDisposal(this);
                
                //if (resource != null) resource.Dispose();
            }
        }
        
    }
}
