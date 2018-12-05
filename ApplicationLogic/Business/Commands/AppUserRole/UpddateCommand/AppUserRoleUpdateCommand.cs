using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.AppUserRole.UpdateCommand.Models;
using Microsoft.AspNetCore.Identity;

namespace ApplicationLogic.Business.Commands.AppUserRole.UpdateCommand
{
    public class AppUserRoleUpdateCommand : AbstractDBCommand<IdentityRole, IAppUserRoleDBRepository>, IAppUserRoleUpdateCommand
    {
        public AppUserRoleUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IAppUserRoleDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public AppUserRoleUpdateCommandOutputDTO Execute(AppUserRoleUpdateCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Update(input);
            }
        }
    }
}
