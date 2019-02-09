using ApplicationLogic.Business.Commands.SampleBoxProduct.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.DeleteCommand
{
    public interface ISampleBoxProductDeleteCommand : ICommandFunc<int, OperationResponse<SampleBoxProductDeleteCommandOutputDTO>>
    {
    }
}