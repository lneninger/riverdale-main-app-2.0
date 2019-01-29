using DomainModel;
using ApplicationLogic.Business.Commands.File.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.File.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.File.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.File.InsertCommand.Models;
using ApplicationLogic.Business.Commands.File.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.File.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;
using DomainModel.File;
using DomainModel.Funza;
using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;

namespace ApplicationLogic.Repositories.DB
{
    public interface IFunzaPackingReferenceDBRepository : IDBRepository
    {
        OperationResponse<DomainModel.Funza.PackingReference> GetById(int id);

        OperationResponse Add(PackingReference entity);

        OperationResponse<PackingReference> GetByFunzaId(int id);

        OperationResponse<PageResult<FunzaPackingPageQueryCommandOutputDTO>> PageQuery(PageQuery<FunzaPackingPageQueryCommandInputDTO> input);

    }
}
