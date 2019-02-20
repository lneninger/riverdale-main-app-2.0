using DomainModel;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.UpdateCommand.Models;
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
    public interface ISaleOpportunityPriceLevelProductDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<SaleOpportunityPriceLevelProduct>> GetAll();

        OperationResponse<PageResult<SaleOpportunityPriceLevelProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityPriceLevelProductPageQueryCommandInputDTO> input);

        OperationResponse<SaleOpportunityPriceLevelProduct> GetById(int id, bool forceRefresh = false);

        OperationResponse<SaleOpportunityPriceLevelProduct> GetByIdWithMedias(int id);

        OperationResponse Insert(SaleOpportunityPriceLevelProduct entity);

        OperationResponse Delete(SaleOpportunityPriceLevelProduct entity);

        OperationResponse LogicalDelete(SaleOpportunityPriceLevelProduct entity);

        void Detach(int id);

    }
}
