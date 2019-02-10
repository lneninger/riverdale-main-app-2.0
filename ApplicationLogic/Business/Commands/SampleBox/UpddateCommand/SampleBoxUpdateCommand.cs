using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBox.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SampleBox.UpdateCommand
{
    public class SampleBoxUpdateCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, ISampleBoxDBRepository>, ISampleBoxUpdateCommand
    {
        public SampleBoxUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SampleBoxUpdateCommandOutputDTO> Execute(SampleBoxUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<SampleBoxUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.Name = input.Name;

                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating Sample Box", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new SampleBoxUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            Name = getByIdResult.Bag.Name,
                            Order = getByIdResult.Bag.Order,
                        };
                    }

                }
            }

            return result;
        }
    }
}
