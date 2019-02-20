using ApplicationLogic.Business.Commands.SampleBox.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBox.PageQueryCommand
{
    public interface ISampleBoxPageQueryCommand : ICommandFunc<PageQuery<SampleBoxPageQueryCommandInputDTO>, OperationResponse<PageResult<SampleBoxPageQueryCommandOutputDTO>>>
    {
    }
}