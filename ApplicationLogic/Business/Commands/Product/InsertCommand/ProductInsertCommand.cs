using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Product.InsertCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Product.InsertCommand
{
    public class ProductInsertCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, IProductDBRepository>, IProductInsertCommand
    {
        public ProductInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductInsertCommandOutputDTO> Execute(ProductInsertCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Insert(input);
            }
        }
    }
}
