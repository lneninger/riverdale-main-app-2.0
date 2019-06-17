using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.BasicProductAlias.UpdateCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.UpdateCommand
{
    public class BasicProductAliasUpdateCommand : AbstractDBCommand<DomainModel.Product.BasicProductAlias, IBasicProductAliasDBRepository>, IBasicProductAliasUpdateCommand
    {
        public BasicProductAliasUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IBasicProductAliasDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<BasicProductAliasUpdateCommandOutputDTO> Execute(BasicProductAliasUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<BasicProductAliasUpdateCommandOutputDTO>();
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
                        result.Bag = new BasicProductAliasUpdateCommandOutputDTO
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
