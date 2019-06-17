using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.BasicProductAlias.DeleteCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.DeleteCommand
{
    public class BasicProductAliasDeleteCommand : AbstractDBCommand<DomainModel.Product.BasicProductAlias, IBasicProductAliasDBRepository>, IBasicProductAliasDeleteCommand
    {
        public BasicProductAliasDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IBasicProductAliasDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<BasicProductAliasDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<BasicProductAliasDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new BasicProductAliasDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,
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
                        result.AddException("Error deleting ProductAlias", ex);
                    }
                }
            }

            return result;
        }
    }
}
