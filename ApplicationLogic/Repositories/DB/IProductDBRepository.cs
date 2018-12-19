﻿using DomainModel;
using ApplicationLogic.Business.Commands.Product.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Product.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.Product.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.Product.InsertCommand.Models;
using ApplicationLogic.Business.Commands.Product.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.Product.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;
using DomainModel.Product;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<ProductGetAllCommandOutputDTO>> GetAll();

        OperationResponse<PageResult<ProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductPageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.Product.AbstractProduct> GetById(int id);

        OperationResponse<ProductInsertCommandOutputDTO> Insert(ProductInsertCommandInputDTO input);

        OperationResponse<ProductUpdateCommandOutputDTO> Update(ProductUpdateCommandInputDTO input);

        OperationResponse<ProductDeleteCommandOutputDTO> Delete(AbstractProduct entity);
    }
}
