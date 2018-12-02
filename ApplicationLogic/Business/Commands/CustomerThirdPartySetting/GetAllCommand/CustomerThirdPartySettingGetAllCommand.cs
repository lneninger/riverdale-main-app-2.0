using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetAllCommand.Models;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetAllCommand
{
    public class CustomerThirdPartyAppSettingGetAllCommand : AbstractDBCommand<DomainModel.CustomerThirdPartyAppSetting, ICustomerThirdPartyAppSettingDBRepository>, ICustomerThirdPartyAppSettingGetAllCommand
    {
        public CustomerThirdPartyAppSettingGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerThirdPartyAppSettingDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public IEnumerable<CustomerThirdPartyAppSettingGetAllCommandOutputDTO> Execute()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetAll();
            }
        }
    }
}
