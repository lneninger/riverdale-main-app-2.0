using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand.Models;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand
{
    public class ProductColorTypeGetByIdCommand : AbstractDBCommand<DomainModel.ProductColorType, IProductColorTypeDBRepository>, IProductColorTypeGetByIdCommand
    {

        public ProductColorTypeGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IProductColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public ProductColorTypeGetByIdCommandOutputDTO Execute(string id)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetById(id);
            }
        }
    }
}
