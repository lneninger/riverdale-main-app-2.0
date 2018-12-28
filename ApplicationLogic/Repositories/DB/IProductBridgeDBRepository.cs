using DomainModel;
using ApplicationLogic.Business.Commands.ProductBridge.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.ProductBridge.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.ProductBridge.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.ProductBridge.InsertCommand.Models;
using ApplicationLogic.Business.Commands.ProductBridge.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.ProductBridge.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;
using DomainModel.Product;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductBridgeDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<CompositionProductBridge>> GetAll();

        OperationResponse<PageResult<ProductBridgePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductBridgePageQueryCommandInputDTO> input);

        OperationResponse<CompositionProductBridge> GetById(int id);

        OperationResponse<CompositionProductBridge> GetByIdWithMedias(int id);

        OperationResponse Insert(CompositionProductBridge entity);

        OperationResponse Delete(CompositionProductBridge entity);

        OperationResponse LogicalDelete(CompositionProductBridge entity);

    }
}
