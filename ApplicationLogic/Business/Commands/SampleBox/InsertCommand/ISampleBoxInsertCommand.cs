using ApplicationLogic.Business.Commands.SampleBox.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBox.InsertCommand
{
    public interface ISampleBoxInsertCommand : ICommandFunc<SampleBoxInsertCommandInputDTO, OperationResponse<SampleBoxInsertCommandOutputDTO>>
    {
    }
}