using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.BasicProductAlias.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.GetAllCommand
{
    public class BasicProductAliasGetAllCommand : AbstractDBCommand<DomainModel.Product.BasicProductAlias, IBasicProductAliasDBRepository>, IBasicProductAliasGetAllCommand
    {
        public BasicProductAliasGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IBasicProductAliasDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<BasicProductAliasGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<BasicProductAliasGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new BasicProductAliasGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Name = entityItem.Name,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }

            return result;
        }
    }
}
