using DomainModel;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;
using DomainModel.Product;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using DomainModel.SaleOpportunity;

namespace ApplicationLogic.Repositories.DB
{
    public interface ISaleOpportunityTargetPriceProductDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<SaleOpportunityTargetPriceProduct>> GetAll();

        OperationResponse<PageResult<SaleOpportunityTargetPriceProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityTargetPriceProductPageQueryCommandInputDTO> input);

        OperationResponse<SaleOpportunityTargetPriceProduct> GetById(int id, bool forceRefresh = false);

        OperationResponse<SaleOpportunityTargetPriceProduct> GetByIdWithMedias(int id);

        OperationResponse Insert(SaleOpportunityTargetPriceProduct entity);

        OperationResponse Delete(SaleOpportunityTargetPriceProduct entity);

        OperationResponse LogicalDelete(SaleOpportunityTargetPriceProduct entity);

        void Detach(int id);

    }
}
