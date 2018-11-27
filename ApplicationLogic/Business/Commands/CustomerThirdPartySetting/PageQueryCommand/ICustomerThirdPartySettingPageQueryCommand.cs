using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.PageQueryCommand
{
    public interface ICustomerThirdPartyAppSettingPageQueryCommand: ICommandFunc<PageQuery<CustomerThirdPartyAppSettingPageQueryCommandInputDTO>, PageResult<CustomerThirdPartyAppSettingPageQueryCommandOutputDTO>>
    {
    }
}