using DomainModel;
using ApplicationLogic.Business.Commands.SampleBox.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SampleBox.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SampleBox.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SampleBox.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SampleBox.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.SampleBox.UpdateCommand.Models;
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
    public interface ISampleBoxDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<SampleBox>> GetAll();

        OperationResponse<PageResult<SampleBoxPageQueryCommandOutputDTO>> PageQuery(PageQuery<SampleBoxPageQueryCommandInputDTO> input);

        OperationResponse<SampleBox> GetById(int id, bool forceRefresh = false);

        OperationResponse<SampleBox> GetByIdWithMedias(int id);

        OperationResponse Insert(SampleBox entity);

        OperationResponse Delete(SampleBox entity);

        OperationResponse LogicalDelete(SampleBox entity);

        void Detach(int id);

    }
}
