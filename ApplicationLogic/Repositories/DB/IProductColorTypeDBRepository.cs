using DomainModel;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.InsertCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.UpdateCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Framework.Core.Messages;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductColorTypeDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<ProductColorType>> GetAll();

        OperationResponse<PageResult<ProductColorTypePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductColorTypePageQueryCommandInputDTO> input);

        OperationResponse<ProductColorType> GetById(string id);

        OperationResponse Insert(ProductColorType entity);

        //OperationResponse<ProductColorTypeUpdateCommandOutputDTO> Update(ProductColorTypeUpdateCommandInputDTO input);
        
        OperationResponse Delete(ProductColorType entity);
    }
}
