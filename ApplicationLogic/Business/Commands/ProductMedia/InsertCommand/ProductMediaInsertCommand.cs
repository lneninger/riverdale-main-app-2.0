using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Business.Commands.ProductMedia.InsertCommand
{
    public class ProductMediaInsertCommand : AbstractDBCommand<DomainModel.Product.ProductMedia, IProductMediaDBRepository>, IProductMediaInsertCommand
    {
        public ProductMediaInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IProductMediaDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductMediaInsertCommandOutputDTO> Execute(ProductMediaInsertCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Insert(input);
            }
        }
    }
}
