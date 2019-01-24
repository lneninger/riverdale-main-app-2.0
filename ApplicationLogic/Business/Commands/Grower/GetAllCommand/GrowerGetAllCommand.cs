using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Grower.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.Grower.GetAllCommand
{
    public class GrowerGetAllCommand : AbstractDBCommand<DomainModel.Company.Grower.Grower, IGrowerDBRepository>, IGrowerGetAllCommand
    {
        public GrowerGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IGrowerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<GrowerGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<GrowerGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new GrowerGetAllCommandOutputDTO
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
