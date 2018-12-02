using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.PageQueryCommand
{
    public class CustomerThirdPartyAppSettingPageQueryCommand : AbstractDBCommand<DomainModel.CustomerThirdPartyAppSetting, ICustomerThirdPartyAppSettingDBRepository>, ICustomerThirdPartyAppSettingPageQueryCommand
    {
        public CustomerThirdPartyAppSettingPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerThirdPartyAppSettingDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public PageResult<CustomerThirdPartyAppSettingPageQueryCommandOutputDTO> Execute(PageQuery<CustomerThirdPartyAppSettingPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
