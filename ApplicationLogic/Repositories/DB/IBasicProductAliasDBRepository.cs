using ApplicationLogic.Business.Commands.BasicProductAlias.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.BasicProductAlias.PageQueryCommand.Models;
using DomainModel.Product;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IBasicProductAliasDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<BasicProductAlias>> GetAll();

        OperationResponse<PageResult<BasicProductAliasPageQueryCommandOutputDTO>> PageQuery(PageQuery<BasicProductAliasPageQueryCommandInputDTO> input);

        OperationResponse<BasicProductAlias> GetById(int id);

        OperationResponse Insert(BasicProductAlias entity);

        //OperationResponse<BasicProductAliasUpdateCommandOutputDTO> Update(BasicProductAliasUpdateCommandInputDTO input);

        OperationResponse<BasicProductAliasDeleteCommandOutputDTO> LogicalDelete(BasicProductAlias entity);

        OperationResponse<BasicProductAliasDeleteCommandOutputDTO> Delete(BasicProductAlias entity);
    }
}
