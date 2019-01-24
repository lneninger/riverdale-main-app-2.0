using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Grower.InsertCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Grower.InsertCommand
{
    public class GrowerInsertCommand : AbstractDBCommand<DomainModel.Company.Grower.Grower, IGrowerDBRepository>, IGrowerInsertCommand
    {
        public GrowerInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IGrowerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<GrowerInsertCommandOutputDTO> Execute(GrowerInsertCommandInputDTO input)
        {
            var result = new OperationResponse<GrowerInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.Company.Grower.Grower
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
                    result.AddError("Error Adding Grower", ex);
                }

                if (result.IsSucceed)
                {
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new GrowerInsertCommandOutputDTO
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
