using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductColorType.InsertCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.ProductColorType.InsertCommand
{
    public class ProductColorTypeInsertCommand : AbstractDBCommand<DomainModel.ProductColorType, IProductColorTypeDBRepository>, IProductColorTypeInsertCommand
    {
        public ProductColorTypeInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IProductColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductColorTypeInsertCommandOutputDTO> Execute(ProductColorTypeInsertCommandInputDTO input)
        {
            var result = new OperationResponse<ProductColorTypeInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.ProductColorType
                {
                    Id = input.Id,
                    Name = input.Name,
                    HexCode = input.HexCode,
                    IsBasicColor = input.IsBasicColor
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
                    result.AddError("Error Adding Product Color Type", ex);
                }

                if (result.IsSucceed)
                {
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new ProductColorTypeInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            Name = getByIdResult.Bag.Name
                            //ERPId = o.ERPId
                        };
                    }

                }
            }

            return result;
        }
    }
}
