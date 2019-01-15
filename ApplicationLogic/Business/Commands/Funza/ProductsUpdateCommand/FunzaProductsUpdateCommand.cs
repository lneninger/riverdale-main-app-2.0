using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Funza.ProductsUpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.Funza.ProductsUpdateCommand
{
    public class ProductInsertCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, IProductDBRepository>, IFunzaProductsUpdateCommand
    {
        public ProductInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FunzaProductsUpdateCommandOutputDTO> Execute(FunzaProductsUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<FunzaProductsUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.Funza.ProductReference()
                {
                };

                try
                {
                    //var insertResult = this.Repository.Insert(entity);
                    //result.AddResponse(insertResult);
                    //if (result.IsSucceed)
                    //{
                    //    dbContextScope.SaveChanges();

                    //}
                }
                catch (Exception ex)
                {
                    result.AddError("Error Adding Product", ex);
                }

                if (result.IsSucceed)
                {
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    //if (result.IsSucceed)
                    //{
                    //    result.Bag = new ProductInsertCommandOutputDTO
                    //    {
                    //        Id = getByIdResult.Bag.Id,
                    //        Name = getByIdResult.Bag.Name
                    //    };
                    //}

                }
            }

            return result;
        }
    }
}
