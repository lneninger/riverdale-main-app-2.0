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

namespace ApplicationLogic.Repositories.DB
{
    public interface IFileDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<DomainModel.File.File>> GetAll();

        OperationResponse<PageResult<FilePageQueryCommandOutputDTO>> PageQuery(PageQuery<FilePageQueryCommandInputDTO> input);

        OperationResponse<File> GetById(int id);

        OperationResponse<FileInsertCommandOutputDTO> Insert(FileInsertCommandInputDTO input);

        OperationResponse<FileUpdateCommandOutputDTO> Update(FileUpdateCommandInputDTO input);

        OperationResponse<FileDeleteCommandOutputDTO> Delete(int id);
    }
}
