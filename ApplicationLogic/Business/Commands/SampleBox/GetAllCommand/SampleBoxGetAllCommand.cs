using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBox.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SampleBox.GetAllCommand
{
    public class SampleBoxGetAllCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SampleBox, ISampleBoxDBRepository>, ISampleBoxGetAllCommand
    {
        public SampleBoxGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<SampleBoxGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<SampleBoxGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new SampleBoxGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Name = entityItem.Name,
                        Order = entityItem.Order,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }

            return result;
        }
    }
}
