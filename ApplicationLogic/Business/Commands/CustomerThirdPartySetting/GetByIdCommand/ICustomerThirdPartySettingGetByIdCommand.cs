using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetByIdCommand.Models;
using System;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetByIdCommand
{
    public interface ICustomerThirdPartyAppSettingGetByIdCommand: ICommandFunc<int, CustomerThirdPartyAppSettingGetByIdCommandOutputDTO>
    {
    }
}