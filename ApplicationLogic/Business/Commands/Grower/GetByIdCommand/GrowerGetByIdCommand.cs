using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Grower.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.Grower.GetByIdCommand
{
    public class GrowerGetByIdCommand : AbstractDBCommand<DomainModel.Company.Grower.Grower, IGrowerDBRepository>, IGrowerGetByIdCommand
    {

        public GrowerGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IGrowerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<GrowerGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<GrowerGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new GrowerGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,
                        ThirdPartySettings = getByIdResult.Bag.GrowerThirdPartyAppSettings.Select(third => new GrowerGetByIdCommandOutputThirdPartySettingsDTO
                        {
                            Id = third.Id,
                            ThirdPartyAppTypeId = third.ThirdPartyAppTypeId,
                            ThirdPartyGrowerId = third.ThirdPartyGrowerId
                        }),
                        Freightout = getByIdResult.Bag.GrowerFreightouts.Select(freightoutItem => new GrowerGetByIdCommandOutputFreightoutDTO
                        {
                            Id = freightoutItem.Id,
                            Cost = freightoutItem.Cost,
                            SecondLeg = freightoutItem.SecondLeg,
                            SurchargeHourly = freightoutItem.SurchargeHourly,
                            SurchargeYearly = freightoutItem.SurchargeYearly,
                            WProtect = freightoutItem.WProtect,
                            DateFrom = freightoutItem.DateFrom,
                            DateTo = freightoutItem.DateTo,

                        }).FirstOrDefault()
                    };
                }
            }

            return result;
        }
    }
}
