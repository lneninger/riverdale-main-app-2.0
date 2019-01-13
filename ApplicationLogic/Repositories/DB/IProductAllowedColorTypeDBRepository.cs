using DomainModel;
using ApplicationLogic.Business.Commands.Product.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Product.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.Product.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.Product.InsertCommand.Models;
using ApplicationLogic.Business.Commands.Product.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;
using DomainModel.Product;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.PageQueryCommand.Models;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductAllowedColorTypeDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<ProductAllowedColorType>> GetAll();

        OperationResponse<PageResult<ProductAllowedColorTypePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductAllowedColorTypePageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.Product.ProductAllowedColorType> GetById(int id);

        OperationResponse Insert(ProductAllowedColorType entity);

        OperationResponse Delete(ProductAllowedColorType entity);

        OperationResponse LogicalDelete(ProductAllowedColorType entity);

    }
}
