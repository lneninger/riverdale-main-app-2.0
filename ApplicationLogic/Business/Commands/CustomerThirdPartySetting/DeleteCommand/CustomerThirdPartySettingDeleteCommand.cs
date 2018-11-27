using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using FocusApplication.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.DeleteCommand.Models;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.DeleteCommand
{
    public class CustomerThirdPartyAppSettingDeleteCommand : AbstractDBCommand<DomainModel.CustomerThirdPartyAppSetting, ICustomerThirdPartyAppSettingDBRepository>, ICustomerThirdPartyAppSettingDeleteCommand
    {
        public CustomerThirdPartyAppSettingDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerThirdPartyAppSettingDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerThirdPartyAppSettingDeleteCommandOutputDTO Execute(int id)
        {
            return this.Repository.Delete(id);
        }
    }
}
