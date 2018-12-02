﻿using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetByIdCommand.Models;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetByIdCommand
{
    public class CustomerThirdPartyAppSettingGetByIdCommand : AbstractDBCommand<DomainModel.CustomerThirdPartyAppSetting, ICustomerThirdPartyAppSettingDBRepository>, ICustomerThirdPartyAppSettingGetByIdCommand
    {

        public CustomerThirdPartyAppSettingGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerThirdPartyAppSettingDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerThirdPartyAppSettingGetByIdCommandOutputDTO Execute(int id)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetById(id);
            }
        }
    }
}