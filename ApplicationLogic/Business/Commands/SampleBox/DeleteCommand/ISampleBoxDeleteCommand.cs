using ApplicationLogic.Business.Commands.SampleBox.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBox.DeleteCommand
{
    public interface ISampleBoxDeleteCommand : ICommandFunc<int, OperationResponse<SampleBoxDeleteCommandOutputDTO>>
    {
    }
}