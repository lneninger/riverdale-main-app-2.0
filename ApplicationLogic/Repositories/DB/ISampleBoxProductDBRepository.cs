using DomainModel;
using ApplicationLogic.Business.Commands.SampleBoxProduct.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SampleBoxProduct.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SampleBoxProduct.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SampleBoxProduct.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SampleBoxProduct.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.SampleBoxProduct.UpdateCommand.Models;
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
    public interface ISampleBoxProductDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<SampleBoxProduct>> GetAll();

        OperationResponse<PageResult<SampleBoxProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<SampleBoxProductPageQueryCommandInputDTO> input);

        OperationResponse<SampleBoxProduct> GetById(int id, bool forceRefresh = false);

        OperationResponse<SampleBoxProduct> GetByIdWithMedias(int id);

        OperationResponse Insert(SampleBoxProduct entity);

        OperationResponse Delete(SampleBoxProduct entity);

        OperationResponse LogicalDelete(SampleBoxProduct entity);

        void Detach(int id);

    }
}
