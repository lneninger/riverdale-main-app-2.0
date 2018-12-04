﻿using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand.Models;

namespace ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand
{
    public class AppUserRoleGetByIdCommand : AbstractDBCommand<DomainModel.Identity.AppUserRole, IAppUserRoleDBRepository>, IAppUserRoleGetByIdCommand
    {

        public AppUserRoleGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IAppUserRoleDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public AppUserRoleGetByIdCommandOutputDTO Execute(string id)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetById(id);
            }
        }
    }
}
