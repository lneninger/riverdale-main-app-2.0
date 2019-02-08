using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Customer.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.Customer.GetByIdCommand
{
    public class CustomerGetByIdCommand : AbstractDBCommand<DomainModel.Company.Customer.Customer, ICustomerDBRepository>, ICustomerGetByIdCommand
    {

        public CustomerGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<CustomerGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<CustomerGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new CustomerGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,

                        ThirdPartySettings = getByIdResult.Bag.CustomerThirdPartyAppSettings.Select(third => new CustomerGetByIdCommandOutputThirdPartySettingsDTO
                        {
                            Id = third.Id,
                            ThirdPartyAppTypeId = third.ThirdPartyAppTypeId,
                            ThirdPartyCustomerId = third.ThirdPartyCustomerId
                        }),
                        Freightout = getByIdResult.Bag.CustomerFreightouts.Select(freightoutItem => new CustomerGetByIdCommandOutputFreightoutDTO
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

                    if (getByIdResult.Bag.CustomerSettings != null)
                    {
                        result.Bag.CustomerSettings = new CustomerGetByIdCommandOutputSettingsDTO
                        {
                            Id = getByIdResult.Bag.CustomerSettings.CustomerId,
                            DefaultDuty = getByIdResult.Bag.CustomerSettings.DefaultDuty,
                            DefaultIsDeliver = getByIdResult.Bag.CustomerSettings.DefaultIsDeliver,
                            DefaultIsWet = getByIdResult.Bag.CustomerSettings.DefaultIsWet,
                            DefaultOther = getByIdResult.Bag.CustomerSettings.DefaultOther,
                            DefaultRebate = getByIdResult.Bag.CustomerSettings.DefaultRebate,
                        };
                    }
                }
            }

            return result;
        }
    }
}
