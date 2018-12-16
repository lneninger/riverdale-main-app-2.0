using DomainModel;
using ApplicationLogic.Business.Commands.ProductMedia.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.ProductMedia.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.ProductMedia.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models;
using ApplicationLogic.Business.Commands.ProductMedia.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.ProductMedia.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductMediaDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<ProductMediaGetAllCommandOutputDTO>> GetAll();

        OperationResponse<PageResult<ProductMediaPageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductMediaPageQueryCommandInputDTO> input);

        OperationResponse<ProductMediaGetByIdCommandOutputDTO> GetById(int id);

        OperationResponse<ProductMediaInsertCommandOutputDTO> Insert(ProductMediaInsertCommandInputDTO input);

        OperationResponse<ProductMediaUpdateCommandOutputDTO> Update(ProductMediaUpdateCommandInputDTO input);

        OperationResponse<ProductMediaDeleteCommandOutputDTO> Delete(int id);
    }
}
