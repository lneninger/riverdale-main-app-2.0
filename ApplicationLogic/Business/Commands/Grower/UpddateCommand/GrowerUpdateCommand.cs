using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Grower.UpdateCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Grower.UpdateCommand
{
    public class GrowerUpdateCommand : AbstractDBCommand<DomainModel.Company.Grower.Grower, IGrowerDBRepository>, IGrowerUpdateCommand
    {
        public GrowerUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IGrowerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<GrowerUpdateCommandOutputDTO> Execute(GrowerUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<GrowerUpdateCommandOutputDTO>();
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
                        result.AddError("Error updating Product Color Type", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new GrowerUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            Name = getByIdResult.Bag.Name
                        };
                    }

                }
            }

            return result;
        }
    }
}
