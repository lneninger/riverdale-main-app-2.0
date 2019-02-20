using ApplicationLogic.Business.Commands.SampleBox.UpdateCommand.Models;

using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBox.UpdateCommand
{
    public interface ISampleBoxUpdateCommand : ICommandFunc<SampleBoxUpdateCommandInputDTO, OperationResponse<SampleBoxUpdateCommandOutputDTO>>
    {
    }
}