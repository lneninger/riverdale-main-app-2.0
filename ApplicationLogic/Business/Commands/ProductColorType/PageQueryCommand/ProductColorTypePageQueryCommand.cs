using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;

namespace ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand
{
    public class ProductColorTypePageQueryCommand : AbstractDBCommand<DomainModel.ProductColorType, IProductColorTypeDBRepository>, IProductColorTypePageQueryCommand
    {
        public ProductColorTypePageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IProductColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public PageResult<ProductColorTypePageQueryCommandOutputDTO> Execute(PageQuery<ProductColorTypePageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
