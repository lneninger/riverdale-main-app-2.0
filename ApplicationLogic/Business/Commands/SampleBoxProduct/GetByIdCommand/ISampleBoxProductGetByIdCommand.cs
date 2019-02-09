using ApplicationLogic.Business.Commands.SampleBoxProduct.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.GetByIdCommand
{
    public interface ISampleBoxProductGetByIdCommand : ICommandFunc<int, OperationResponse<SampleBoxProductGetByIdCommandOutputDTO>>
    {
    }
}