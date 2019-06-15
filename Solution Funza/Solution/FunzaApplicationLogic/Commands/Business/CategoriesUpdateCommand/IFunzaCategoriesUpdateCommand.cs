using FunzaApplicationLogic.Commands.Funza.CategoriesUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.CategoriesUpdateCommand.Models
{
    public interface IFunzaCategoriesUpdateCommand: ICommandFunc<IEnumerable<FunzaCategoriesUpdateCommandInputDTO>, OperationResponse<FunzaCategoriesUpdateCommandOutputDTO>>
    {
    }
}