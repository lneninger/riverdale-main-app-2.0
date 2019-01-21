using ApplicationLogic.Business.Commands.Funza.ProductsUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.ColorsUpdateCommand.Models
{
    public interface IFunzaColorsUpdateCommand : ICommandFunc<IEnumerable<FunzaColorsUpdateCommandInputDTO>, OperationResponse<FunzaColorsUpdateCommandOutputDTO>>
    {
    }
}