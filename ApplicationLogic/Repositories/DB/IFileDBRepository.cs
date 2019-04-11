using ApplicationLogic.Business.Commands.File.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.File.PageQueryCommand.Models;
using DomainModel.File;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IFileDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<DomainModel.File.File>> GetAll();

        OperationResponse<PageResult<FilePageQueryCommandOutputDTO>> PageQuery(PageQuery<FilePageQueryCommandInputDTO> input);

        OperationResponse<File> GetById(int id);

        OperationResponse<DomainModel.File.File> Insert(File input);

        OperationResponse<FileDeleteCommandOutputDTO> Delete(int id);
    }
}
