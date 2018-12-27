using ApplicationLogic.Repositories.DB;
using EntityFrameworkCore.DbContextScope;
using Framework.Autofac;
using Framework.EF.DbContextImpl;
using Framework.SignalR;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.SignalR
{
    public class GlobalHub : BaseSignalR
    {
        public GlobalHub(ICurrentUserService currentUserService, IDbContextScopeFactory dbContextScopeFactory, IAppUserDBRepository repository) : base(currentUserService, dbContextScopeFactory, repository)
        {
        }

        public void EntityChanged(SignalREventArgs @event)
        {
            using (var scope = IoCGlobal.NewScope())
            {
                Clients.All.SendCoreAsync("dataChanged", new object[] { @event });
            }
        }

    }
}
