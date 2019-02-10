using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBox.DeleteCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using DomainModel.Product;

namespace ApplicationLogic.Business.Commands.SampleBox.DeleteCommand
{
    public class SampleBoxDeleteCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SampleBox, ISampleBoxDBRepository>, ISampleBoxDeleteCommand
    {
        public SampleBoxDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SampleBoxDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SampleBoxDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new SampleBoxDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,
                        Order = getByIdResult.Bag.Order
                    };
                }

                var deleteResult = this.Repository.Delete(getByIdResult.Bag);
                result.AddResponse(deleteResult);
                if (result.IsSucceed)
                {
                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddException("Error deleting Product", ex);
                    }
                }
            }

            return result;
        }
    }
}
