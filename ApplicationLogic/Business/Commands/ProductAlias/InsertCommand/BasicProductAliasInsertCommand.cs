using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.BasicProductAlias.InsertCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.InsertCommand
{
    public class BasicProductAliasInsertCommand : AbstractDBCommand<DomainModel.Product.BasicProductAlias, IBasicProductAliasDBRepository>, IBasicProductAliasInsertCommand
    {
        public BasicProductAliasInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IBasicProductAliasDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<BasicProductAliasInsertCommandOutputDTO> Execute(BasicProductAliasInsertCommandInputDTO input)
        {
            var result = new OperationResponse<BasicProductAliasInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.Product.BasicProductAlias
                {
                    Name = input.Name,
                };

                try
                {
                    var insertResult = this.Repository.Insert(entity);
                    result.AddResponse(insertResult);
                    if (result.IsSucceed)
                    {
                        dbContextScope.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    result.AddError("Error Adding ProductAlias", ex);
                }

                if (result.IsSucceed)
                {
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new BasicProductAliasInsertCommandOutputDTO
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
