using Framework.Core.Messages;
using Framework.Core.Models;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetCategoriesCommand.Models;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetColorsCommand.Models;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand.Models;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetProductsCommand.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaApplicationLogic.Repositories.DB
{
    public interface IMastersRepository
    {
        OperationResponse<IEnumerable<FunzaGetProductsCommandOutput>> GetProducts(string getProductsURL, string accessToken);

        OperationResponse<IEnumerable<FunzaGetColorsCommandOutput>> GetColors(string getColorsURL, string accessToken);

        OperationResponse<IEnumerable<FunzaGetCategoriesCommandOutput>> GetCategories(string getProductsURL, string accessToken);

        OperationResponse<IEnumerable<FunzaGetPackingsCommandOutputDTO>> GetPackings(string getProductsURL, string accessToken);
    }
}
