using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Product.GetByIdCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Product.GetByIdCommand
{
    public class ProductGetByIdCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, IProductDBRepository>, IProductGetByIdCommand
    {

        public ProductGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductGetByIdCommandOutputDTO> Execute(int id)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetById(id);
            }
        }
    }
}
