using ApplicationLogic.Business.Commands.SampleBox.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.SampleBox.GetByIdCommand
{
    public interface ISampleBoxGetByIdCommand : ICommandFunc<int, OperationResponse<SampleBoxGetByIdCommandOutputDTO>>
    {
    }
}