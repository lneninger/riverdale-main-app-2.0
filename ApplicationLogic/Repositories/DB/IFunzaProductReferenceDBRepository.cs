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

namespace ApplicationLogic.Repositories.DB
{
    public interface IFunzaProductReferenceDBRepository: IDBRepository
    {
        OperationResponse<DomainModel.Funza.ProductReference> GetById(int id);

        OperationResponse<ProductReference> Add(ProductReference entity);
    }
}
