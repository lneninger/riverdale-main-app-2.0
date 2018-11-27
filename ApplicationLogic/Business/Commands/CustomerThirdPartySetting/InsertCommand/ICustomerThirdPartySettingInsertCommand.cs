using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.InsertCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.InsertCommand
{
    public interface ICustomerThirdPartyAppSettingInsertCommand: ICommandFunc<CustomerThirdPartyAppSettingInsertCommandInputDTO, CustomerThirdPartyAppSettingInsertCommandOutputDTO>
    {
    }
}