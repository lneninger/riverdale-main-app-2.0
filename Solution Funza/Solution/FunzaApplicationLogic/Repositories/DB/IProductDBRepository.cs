using DomainModel;
using DomainModel.Funza;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.Funza.ProductPageQueryCommand.Models;
using FunzaApplicationLogic.Repositories.DB;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductDBRepository: IDBRepository
    {
        OperationResponse<Product> GetById(int id);

        OperationResponse Add(Product entity);

        OperationResponse<Product> GetByFunzaId(int id);

        OperationResponse<PageResult<ProductPageQueryCommandOutput>> PageQuery(PageQuery<ProductPageQueryCommandInput> input);

        OperationResponse<IEnumerable<Product>> GetAll();

        OperationResponse DeleteNotInIntegration(Guid integrationId);
    }
}
