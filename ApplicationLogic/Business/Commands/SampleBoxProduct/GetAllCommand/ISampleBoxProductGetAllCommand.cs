using ApplicationLogic.Business.Commands.SampleBoxProduct.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.GetAllCommand
{
    public interface ISampleBoxProductGetAllCommand : ICommandAction<OperationResponse<IEnumerable<SampleBoxProductGetAllCommandOutputDTO>>>
    {
    }
}