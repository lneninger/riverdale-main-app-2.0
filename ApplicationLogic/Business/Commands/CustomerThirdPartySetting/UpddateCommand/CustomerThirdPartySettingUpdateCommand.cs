﻿using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using FocusApplication.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.UpdateCommand.Models;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.UpdateCommand
{
    public class CustomerThirdPartyAppSettingUpdateCommand : AbstractDBCommand<DomainModel.CustomerThirdPartyAppSetting, ICustomerThirdPartyAppSettingDBRepository>, ICustomerThirdPartyAppSettingUpdateCommand
    {
        public CustomerThirdPartyAppSettingUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerThirdPartyAppSettingDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerThirdPartyAppSettingUpdateCommandOutputDTO Execute(CustomerThirdPartyAppSettingUpdateCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Update(input);
            }
        }
    }
}
