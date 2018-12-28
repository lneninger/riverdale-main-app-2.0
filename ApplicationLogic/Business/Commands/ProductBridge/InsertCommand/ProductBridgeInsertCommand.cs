﻿using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductBridge.InsertCommand.Models;
using Framework.Core.Messages;
using ApplicationLogic.Business.Commands.Product.Commons;
using DomainModel.Product;

namespace ApplicationLogic.Business.Commands.ProductBridge.InsertCommand
{
    public class ProductBridgeInsertCommand : AbstractDBCommand<DomainModel.Product.CompositionProductBridge, IProductBridgeDBRepository>, IProductBridgeInsertCommand
    {
        public ProductBridgeInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IProductBridgeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductBridgeInsertCommandOutputDTO> Execute(ProductBridgeInsertCommandInputDTO input)
        {
            var result = new OperationResponse<ProductBridgeInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.Product.CompositionProductBridge
                {
                    CompositionProductId = input.ProductId,
                    CompositionItemId = input.RelatedProductId,
                    Stems = input.Stems
                };

                try
                {
                    var insertResult = this.Repository.Insert(entity);
                    result.AddResponse(insertResult);
                    if (result.IsSucceed)
                    {
                        dbContextScope.SaveChanges();

                    }
                }
                catch (Exception ex)
                {
                    result.AddError("Error Adding Product", ex);
                }

                if (result.IsSucceed)
                {
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new ProductBridgeInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            ProductId = getByIdResult.Bag.CompositionProductId,
                            RelatedProductId = getByIdResult.Bag.CompositionItemId,
                            Stems = getByIdResult.Bag.Stems,

                        };
                    }

                }
            }

            return result;
        }
    }
}
