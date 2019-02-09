using ApplicationLogic.Business.Commands.SampleBoxProduct.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.PageQueryCommand
{
    public interface ISampleBoxProductPageQueryCommand : ICommandFunc<PageQuery<SampleBoxProductPageQueryCommandInputDTO>, OperationResponse<PageResult<SampleBoxProductPageQueryCommandOutputDTO>>>
    {
    }
}