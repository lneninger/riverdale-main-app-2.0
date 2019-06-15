using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.GetByIdCommand
{
    public class ProductGetByIdCommand : AbstractDBCommand<DomainModel.Product, IProductDBRepository>, IProductGetByIdCommand
    {

        public ProductGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductGetByIdCommandOutput> Execute(int id)
        {
            var result = new OperationResponse<ProductGetByIdCommandOutput>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
            }

            return result;



        }
    }
}
