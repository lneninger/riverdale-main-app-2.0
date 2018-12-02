using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.AppUser.DeleteCommand.Models;

namespace ApplicationLogic.Business.Commands.AppUser.DeleteCommand
{
    public class AppUserDeleteCommand : AbstractDBCommand<DomainModel.Identity.AppUser, IAppUserDBRepository>, IAppUserDeleteCommand
    {
        public AppUserDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IAppUserDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public AppUserDeleteCommandOutputDTO Execute(string id)
        {
            return this.Repository.Delete(id);
        }
    }
}
