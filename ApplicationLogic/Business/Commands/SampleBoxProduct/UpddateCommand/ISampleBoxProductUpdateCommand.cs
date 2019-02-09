using ApplicationLogic.Business.Commands.SampleBoxProduct.UpdateCommand.Models;

using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.UpdateCommand
{
    public interface ISampleBoxProductUpdateCommand : ICommandFunc<SampleBoxProductUpdateCommandInputDTO, OperationResponse<SampleBoxProductUpdateCommandOutputDTO>>
    {
    }
}