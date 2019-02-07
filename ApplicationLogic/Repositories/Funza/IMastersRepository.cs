using ApplicationLogic.Business.Commands.FunzaIntegrator.GetCategoriesCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetColorsCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetPackingsCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Repositories.Funza
{
    public interface IMastersRepository
    {
        OperationResponse<IEnumerable<FunzaGetProductsCommandOutputDTO>> GetProducts(string getProductsURL, string accessToken);

        OperationResponse<IEnumerable<FunzaGetColorsCommandOutputDTO>> GetColors(string getColorsURL, string accessToken);

        OperationResponse<IEnumerable<FunzaGetCategoriesCommandOutputDTO>> GetCategories(string getProductsURL, string accessToken);

        OperationResponse<IEnumerable<FunzaGetPackingsCommandOutputDTO>> GetPackings(string getProductsURL, string accessToken);
    }
}
