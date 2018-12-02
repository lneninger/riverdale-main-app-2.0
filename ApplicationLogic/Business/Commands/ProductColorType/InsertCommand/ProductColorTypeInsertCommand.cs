using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductColorType.InsertCommand.Models;

namespace ApplicationLogic.Business.Commands.ProductColorType.InsertCommand
{
    public class ProductColorTypeInsertCommand : AbstractDBCommand<DomainModel.ProductColorType, IProductColorTypeDBRepository>, IProductColorTypeInsertCommand
    {
        public ProductColorTypeInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IProductColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public ProductColorTypeInsertCommandOutputDTO Execute(ProductColorTypeInsertCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Insert(input);
            }
        }
    }
}
