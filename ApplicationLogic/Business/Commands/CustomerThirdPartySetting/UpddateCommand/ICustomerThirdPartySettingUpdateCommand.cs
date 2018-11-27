using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.UpdateCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.UpdateCommand
{
    public interface ICustomerThirdPartyAppSettingUpdateCommand: ICommandFunc<CustomerThirdPartyAppSettingUpdateCommandInputDTO, CustomerThirdPartyAppSettingUpdateCommandOutputDTO>
    {
    }
}