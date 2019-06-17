using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.BasicProductAlias.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.GetByIdCommand
{
    public class BasicProductAliasGetByIdCommand : AbstractDBCommand<DomainModel.Product.BasicProductAlias, IBasicProductAliasDBRepository>, IBasicProductAliasGetByIdCommand
    {

        public BasicProductAliasGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IBasicProductAliasDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<BasicProductAliasGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<BasicProductAliasGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new BasicProductAliasGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,
                        //ThirdPartySettings = getByIdResult.Bag.ProductAliasThirdPartyAppSettings.Select(third => new ProductAliasGetByIdCommandOutputThirdPartySettingsDTO
                        //{
                        //    Id = third.Id,
                        //    ThirdPartyAppTypeId = third.ThirdPartyAppTypeId,
                        //    ThirdPartyProductAliasId = third.ThirdPartyProductAliasId
                        //}),
                        //Freightout = getByIdResult.Bag.ProductAliasFreightouts.Select(freightoutItem => new ProductAliasGetByIdCommandOutputFreightoutDTO
                        //{
                        //    Id = freightoutItem.Id,
                        //    Cost = freightoutItem.Cost,
                        //    SecondLeg = freightoutItem.SecondLeg,
                        //    SurchargeHourly = freightoutItem.SurchargeHourly,
                        //    SurchargeYearly = freightoutItem.SurchargeYearly,
                        //    WProtect = freightoutItem.WProtect,
                        //    DateFrom = freightoutItem.DateFrom,
                        //    DateTo = freightoutItem.DateTo,

                        //}).FirstOrDefault()
                    };
                }
            }

            return result;
        }
    }
}
