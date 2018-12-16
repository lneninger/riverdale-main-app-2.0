using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductMedia.UpdateCommand.Models;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Business.Commands.ProductMedia.UpdateCommand
{
    public class ProductMediaMediaUpdateCommand : AbstractDBCommand<DomainModel.Product.ProductMedia, IProductMediaDBRepository>, IProductMediaUpdateCommand
    {
        public ProductMediaMediaUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IProductMediaDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductMediaUpdateCommandOutputDTO> Execute(ProductMediaUpdateCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Update(input);
            }
        }
    }
}
