using DomainModel;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.UpdateCommand.Models;
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
    public interface ISaleOpportunityProductDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<SaleOpportunityProduct>> GetAll();

        OperationResponse<PageResult<SaleOpportunityProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityProductPageQueryCommandInputDTO> input);

        OperationResponse<SaleOpportunityProduct> GetById(int id, bool forceRefresh = false);

        OperationResponse<SaleOpportunityProduct> GetByIdWithMedias(int id);

        OperationResponse Insert(SaleOpportunityProduct entity);

        OperationResponse Delete(SaleOpportunityProduct entity);

        OperationResponse LogicalDelete(SaleOpportunityProduct entity);

        void Detach(int id);

    }
}
