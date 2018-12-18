using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Product.DeleteCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Product.DeleteCommand
{
    public class ProductDeleteCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, IProductDBRepository>, IProductDeleteCommand
    {
        public ProductDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductDeleteCommandOutputDTO> Execute(int id)
        {
            return this.Repository.Delete(id);
        }
    }
}
