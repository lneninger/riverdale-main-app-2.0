using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.AppUserRole.DeleteCommand.Models;

namespace ApplicationLogic.Business.Commands.AppUserRole.DeleteCommand
{
    public class AppUserRoleDeleteCommand : AbstractDBCommand<DomainModel.Identity.AppUserRole, IAppUserRoleDBRepository>, IAppUserRoleDeleteCommand
    {
        public AppUserRoleDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IAppUserRoleDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public AppUserRoleDeleteCommandOutputDTO Execute(string id)
        {
            return this.Repository.Delete(id);
        }
    }
}
