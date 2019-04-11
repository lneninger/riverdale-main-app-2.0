using ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand.Models;
using DomainModel;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

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

        OperationResponse<ProductColorTypeDeleteCommandOutputDTO> LogicalDelete(ProductColorType entity);
    }
}
