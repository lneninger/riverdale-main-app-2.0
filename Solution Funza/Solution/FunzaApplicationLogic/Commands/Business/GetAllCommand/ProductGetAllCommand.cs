using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using Framework.Commands;
using DomainModel;

namespace FunzaApplicationLogic.Commands.Funza.GetAllCommand
{
    public class ProductGetAllCommand : AbstractDBCommand<Product, IProductDBRepository>, IProductGetAllCommand
    {
        public ProductGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<ProductGetAllCommandOutput>> Execute()
        {
            var result = new OperationResponse<IEnumerable<ProductGetAllCommandOutput>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new ProductGetAllCommandOutput
                    {
                        Id = entityItem.Id,

                        ProductId = entityItem.Id,
                        SpecieId = entityItem.SpecieId,
                        VariatyId = entityItem.VariatyId,
                        SizeId = entityItem.SizeId,
                        ColorId = entityItem.ColorId,
                        Code = entityItem.Code,

                    }).ToList();
                }
            }

            return result;
        }
    }
}
