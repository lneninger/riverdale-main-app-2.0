using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductMedia.GetAllCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.ProductMedia.GetAllCommand
{
    public class ProductMediaGetAllCommand : AbstractDBCommand<DomainModel.Product.ProductMedia, IProductMediaDBRepository>, IProductMediaGetAllCommand
    {
        public ProductMediaGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IProductMediaDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<ProductMediaGetAllCommandOutputDTO>> Execute()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetAll();
            }
        }
    }
}
