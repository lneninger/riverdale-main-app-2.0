﻿using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.DeleteCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.DeleteCommand
{
    public interface ICustomerThirdPartyAppSettingDeleteCommand: ICommandFunc<int, OperationResponse<CustomerThirdPartyAppSettingDeleteCommandOutputDTO>>
    {
    }
}