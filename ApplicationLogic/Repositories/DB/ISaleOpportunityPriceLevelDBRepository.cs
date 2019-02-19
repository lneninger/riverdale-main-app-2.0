using DomainModel;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;
using DomainModel.SaleOpportunity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApplicationLogic.Repositories.DB
{
    public interface ISaleOpportunityPriceLevelDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<SaleOpportunityPriceLevel>> GetAll();

        OperationResponse<PageResult<SaleOpportunityPriceLevelPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityPriceLevelPageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.SaleOpportunity.SaleOpportunityPriceLevel> GetById(int id);

        OperationResponse<DomainModel.SaleOpportunity.SaleOpportunityPriceLevel> GetByIdWithProducts(int id);

        OperationResponse Insert(SaleOpportunityPriceLevel entity);

        OperationResponse Delete(SaleOpportunityPriceLevel entity);

        OperationResponse LogicalDelete(SaleOpportunityPriceLevel entity);

    }
}
