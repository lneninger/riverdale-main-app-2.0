using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.InsertCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.InsertCommand
{
    public interface ICustomerThirdPartyAppSettingInsertCommand: ICommandFunc<CustomerThirdPartyAppSettingInsertCommandInputDTO, OperationResponse<CustomerThirdPartyAppSettingInsertCommandOutputDTO>>
    {
    }
}