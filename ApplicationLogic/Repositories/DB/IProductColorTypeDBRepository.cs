using DomainModel;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.InsertCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.UpdateCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand.Models;

namespace FocusApplication.Repositories.DB
{
    public interface IProductColorTypeDBRepository: IDBRepository
    {
        IEnumerable<ProductColorTypeGetAllCommandOutputDTO> GetAll();
        PageResult<ProductColorTypePageQueryCommandOutputDTO> PageQuery(PageQuery<ProductColorTypePageQueryCommandInputDTO> input);
        ProductColorTypeGetByIdCommandOutputDTO GetById(string id);
        ProductColorTypeInsertCommandOutputDTO Insert(ProductColorTypeInsertCommandInputDTO input);
        ProductColorTypeUpdateCommandOutputDTO Update(ProductColorTypeUpdateCommandInputDTO input);
        ProductColorTypeDeleteCommandOutputDTO Delete(string id);
    }
}
