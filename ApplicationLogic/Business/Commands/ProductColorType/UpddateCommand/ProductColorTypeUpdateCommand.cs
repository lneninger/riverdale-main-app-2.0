using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductColorType.UpdateCommand.Models;

namespace ApplicationLogic.Business.Commands.ProductColorType.UpdateCommand
{
    public class ProductColorTypeUpdateCommand : AbstractDBCommand<DomainModel.ProductColorType, IProductColorTypeDBRepository>, IProductColorTypeUpdateCommand
    {
        public ProductColorTypeUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IProductColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public ProductColorTypeUpdateCommandOutputDTO Execute(ProductColorTypeUpdateCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Update(input);
            }
        }
    }
}
