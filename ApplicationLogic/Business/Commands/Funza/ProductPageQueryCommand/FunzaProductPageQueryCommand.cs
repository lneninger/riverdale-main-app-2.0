using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Funza.ProductPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Funza.ProductPageQueryCommand
{
    public class FunzaProductPageQueryCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, IFunzaProductReferenceDBRepository>, IFunzaProductPageQueryCommand
    {
        public FunzaProductPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IFunzaProductReferenceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<FunzaProductPageQueryCommandOutputDTO>> Execute(PageQuery<FunzaProductPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
