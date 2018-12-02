using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.AppUser.UpdateCommand.Models;

namespace ApplicationLogic.Business.Commands.AppUser.UpdateCommand
{
    public class AppUserUpdateCommand : AbstractDBCommand<DomainModel.Identity.AppUser, IAppUserDBRepository>, IAppUserUpdateCommand
    {
        public AppUserUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IAppUserDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public AppUserUpdateCommandOutputDTO Execute(AppUserUpdateCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Update(input);
            }
        }
    }
}
