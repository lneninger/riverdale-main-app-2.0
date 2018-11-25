using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using FocusApplication.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand.Models;

namespace ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand
{
    public class ProductColorTypeDeleteCommand : AbstractDBCommand<DomainModel.ProductColorType, IProductColorTypeDBRepository>, IProductColorTypeDeleteCommand
    {
        public ProductColorTypeDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IProductColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public ProductColorTypeDeleteCommandOutputDTO Execute(string id)
        {
            return this.Repository.Delete(id);
        }
    }
}
