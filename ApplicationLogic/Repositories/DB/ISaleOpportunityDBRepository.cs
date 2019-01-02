using DomainModel;
using ApplicationLogic.Business.Commands.SaleOpportunity.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunity.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunity.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunity.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunity.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;
using DomainModel.SaleOpportunity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApplicationLogic.Repositories.DB
{
    public interface ISaleOpportunityDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<SaleOpportunity>> GetAll();

        OperationResponse<PageResult<SaleOpportunityPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityPageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.SaleOpportunity.SaleOpportunity> GetById(int id);

        OperationResponse<DomainModel.SaleOpportunity.SaleOpportunity> GetByIdWithProducts(int id);

        OperationResponse Insert(SaleOpportunity entity);

        OperationResponse Delete(SaleOpportunity entity);

        OperationResponse LogicalDelete(SaleOpportunity entity);

    }
}
