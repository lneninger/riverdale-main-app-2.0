using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetAllCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetAllCommand
{
    public interface ICustomerThirdPartyAppSettingGetAllCommand: ICommandAction<OperationResponse<IEnumerable<CustomerThirdPartyAppSettingGetAllCommandOutputDTO>>>
    {
    }
}