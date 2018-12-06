using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand.Models;
using Microsoft.AspNetCore.Identity;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand
{
    public class AppUserRoleGetByIdCommand : AbstractDBCommand<IdentityRole, IAppUserRoleDBRepository>, IAppUserRoleGetByIdCommand
    {

        public AppUserRoleGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IAppUserRoleDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<AppUserRoleGetByIdCommandOutputDTO> Execute(string id)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetById(id);
            }
        }
    }
}
