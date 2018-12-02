using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.AppUser.GetAllCommand.Models;

namespace ApplicationLogic.Business.Commands.AppUser.GetAllCommand
{
    public class AppUserGetAllCommand : AbstractDBCommand<DomainModel.Identity.AppUser, IAppUserDBRepository>, IAppUserGetAllCommand
    {
        public AppUserGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IAppUserDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public IEnumerable<AppUserGetAllCommandOutputDTO> Execute()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetAll();
            }
        }
    }
}
