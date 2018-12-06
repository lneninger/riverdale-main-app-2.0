using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.AppUser.GetByIdCommand.Models;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Business.Commands.AppUser.GetByIdCommand
{
    public class AppUserGetByIdCommand : AbstractDBCommand<DomainModel.Identity.AppUser, IAppUserDBRepository>, IAppUserGetByIdCommand
    {

        public AppUserGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IAppUserDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<AppUserGetByIdCommandOutputDTO> Execute(string id)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetById(id);
            }
        }
    }
}
