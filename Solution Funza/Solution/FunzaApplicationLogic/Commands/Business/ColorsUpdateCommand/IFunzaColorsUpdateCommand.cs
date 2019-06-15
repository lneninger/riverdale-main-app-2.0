using FunzaApplicationLogic.Commands.Funza.ProductsUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.ColorsUpdateCommand.Models
{
    public interface IFunzaColorsUpdateCommand : ICommandFunc<IEnumerable<FunzaColorsUpdateCommandInputDTO>, OperationResponse<FunzaColorsUpdateCommandOutputDTO>>
    {
    }
}