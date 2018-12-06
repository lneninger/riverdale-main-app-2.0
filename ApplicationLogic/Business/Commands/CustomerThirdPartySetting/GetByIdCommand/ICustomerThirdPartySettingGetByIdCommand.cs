using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetByIdCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetByIdCommand
{
    public interface ICustomerThirdPartyAppSettingGetByIdCommand: ICommandFunc<int, OperationResponse<CustomerThirdPartyAppSettingGetByIdCommandOutputDTO>>
    {
    }
}