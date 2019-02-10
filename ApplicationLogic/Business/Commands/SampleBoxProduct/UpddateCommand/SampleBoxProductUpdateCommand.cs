﻿using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBoxProduct.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.UpdateCommand
{
    public class SampleBoxProductUpdateCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, ISampleBoxProductDBRepository>, ISampleBoxProductUpdateCommand
    {
        public SampleBoxProductUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SampleBoxProductUpdateCommandOutputDTO> Execute(SampleBoxProductUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<SampleBoxProductUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.ProductAmount = input.ProductAmount;

                    var newAllowedProductColorTypeId = getByIdResult.Bag.Product.ProductAllowedColorTypes.Where(allowedColorTypeItem => allowedColorTypeItem.ProductColorTypeId == input.ProductColorTypeId).Select(allowedColorTypeItem => allowedColorTypeItem.Id).FirstOrDefault();
                    if (newAllowedProductColorTypeId != default(int))
                    {
                        getByIdResult.Bag.ProductAllowedColorTypeId = newAllowedProductColorTypeId;
                    }

                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating Product Color Type", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new SampleBoxProductUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            SampleBoxId = getByIdResult.Bag.SampleBoxId,
                            ProductId = getByIdResult.Bag.ProductId,
                            ProductAmount = getByIdResult.Bag.ProductAmount,
                            ProductName = getByIdResult.Bag.Product.Name,
                            ProductTypeId = getByIdResult.Bag.Product.ProductTypeId,
                            ProductTypeName = getByIdResult.Bag.Product.ProductType.Name,
                            ProductTypeDescription = getByIdResult.Bag.Product.ProductType.Description,
                            ProductPictureId = getByIdResult.Bag.Product.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault(),
                            ProductColorTypeId = getByIdResult.Bag.ProductAllowedColorType?.ProductColorTypeId
                        };
                    }

                }
            }

            return result;
        }
    }
}