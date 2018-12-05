﻿using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.AppUserRole.GetAllCommand.Models;
using Microsoft.AspNetCore.Identity;

namespace ApplicationLogic.Business.Commands.AppUserRole.GetAllCommand
{
    public class AppUserRoleGetAllCommand : AbstractDBCommand<IdentityRole, IAppUserRoleDBRepository>, IAppUserRoleGetAllCommand
    {
        public AppUserRoleGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IAppUserRoleDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public IEnumerable<AppUserRoleGetAllCommandOutputDTO> Execute()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetAll();
            }
        }
    }
}