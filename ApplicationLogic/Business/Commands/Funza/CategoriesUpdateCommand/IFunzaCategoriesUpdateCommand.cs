using ApplicationLogic.Business.Commands.Funza.CategoriesUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.CategoriesUpdateCommand.Models
{
    public interface IFunzaCategoriesUpdateCommand: ICommandFunc<IEnumerable<FunzaCategoriesUpdateCommandInputDTO>, OperationResponse<FunzaCategoriesUpdateCommandOutputDTO>>
    {
    }
}