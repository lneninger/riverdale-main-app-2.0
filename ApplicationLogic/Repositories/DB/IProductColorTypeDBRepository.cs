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
using Framework.Storage.DataHolders.Messages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductColorTypeDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<ProductColorTypeGetAllCommandOutputDTO>> GetAll();

        OperationResponse<PageResult<ProductColorTypePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductColorTypePageQueryCommandInputDTO> input);

        OperationResponse<ProductColorTypeGetByIdCommandOutputDTO> GetById(string id);

        OperationResponse<ProductColorTypeInsertCommandOutputDTO> Insert(ProductColorTypeInsertCommandInputDTO input);

        OperationResponse<ProductColorTypeUpdateCommandOutputDTO> Update(ProductColorTypeUpdateCommandInputDTO input);
        
        OperationResponse<ProductColorTypeDeleteCommandOutputDTO> Delete(string id);
    }
}
