using DomainModel;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;
using DomainModel.SaleOpportunity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApplicationLogic.Repositories.DB
{
    public interface ISaleOpportunityTargetPriceDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<SaleOpportunityTargetPrice>> GetAll();

        OperationResponse<PageResult<SaleOpportunityTargetPricePageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityTargetPricePageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice> GetById(int id);

        OperationResponse<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice> GetByIdWithProducts(int id);

        OperationResponse Insert(SaleOpportunityTargetPrice entity);

        OperationResponse Delete(SaleOpportunityTargetPrice entity);

        OperationResponse LogicalDelete(SaleOpportunityTargetPrice entity);

    }
}
