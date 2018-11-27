using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetAllCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetAllCommand
{
    public interface ICustomerThirdPartyAppSettingGetAllCommand: ICommandAction<IEnumerable<CustomerThirdPartyAppSettingGetAllCommandOutputDTO>>
    {
    }
}