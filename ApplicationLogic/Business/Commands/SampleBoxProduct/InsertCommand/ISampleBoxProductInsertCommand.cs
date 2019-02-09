using ApplicationLogic.Business.Commands.SampleBoxProduct.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.InsertCommand
{
    public interface ISampleBoxProductInsertCommand : ICommandFunc<SampleBoxProductInsertCommandInputDTO, OperationResponse<SampleBoxProductInsertCommandOutputDTO>>
    {
    }
}