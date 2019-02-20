using ApplicationLogic.Business.Commands.SampleBox.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBox.GetAllCommand
{
    public interface ISampleBoxGetAllCommand : ICommandAction<OperationResponse<IEnumerable<SampleBoxGetAllCommandOutputDTO>>>
    {
    }
}