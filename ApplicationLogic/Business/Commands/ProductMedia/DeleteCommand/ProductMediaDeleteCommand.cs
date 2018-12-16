using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductMedia.DeleteCommand.Models;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Business.Commands.ProductMedia.DeleteCommand
{
    public class ProductMediaDeleteCommand : AbstractDBCommand<DomainModel.Product.ProductMedia, IProductMediaDBRepository>, IProductMediaDeleteCommand
    {
        public ProductMediaDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IProductMediaDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductMediaDeleteCommandOutputDTO> Execute(int id)
        {
            return this.Repository.Delete(id);
        }
    }
}
