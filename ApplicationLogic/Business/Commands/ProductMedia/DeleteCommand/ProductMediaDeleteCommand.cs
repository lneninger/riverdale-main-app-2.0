using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductMedia.DeleteCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.ProductMedia.DeleteCommand
{
    public class ProductMediaDeleteCommand : AbstractDBCommand<DomainModel.Product.ProductMedia, IProductMediaDBRepository>, IProductMediaDeleteCommand
    {
        public ProductMediaDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IProductMediaDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductMediaDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<ProductMediaDeleteCommandOutputDTO>();

            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                try
                {
                    var internalResult = this.Repository.Delete(id);
                    result.AddResponse(internalResult);
                    if (result.IsSucceed)
                    {
                        dbContextScope.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    result.AddError("Error deleting product media", ex);
                }

                if (result.IsSucceed)
                {
                    var dbRecordResponse = this.Repository.GetById(id, true);
                    if (result.IsSucceed && result.Warnings.Count() == 0)
                    {
                        result.Bag = new ProductMediaDeleteCommandOutputDTO
                        {
                            Id = dbRecordResponse.Bag.Id,
                            Name = dbRecordResponse.Bag.FileRepository.FileName,
                            ProductId = dbRecordResponse.Bag.ProductId,
                            IsDeleted = dbRecordResponse.Bag.IsDeleted,
                            DeletedAt = dbRecordResponse.Bag.DeletedAt,
                        };
                    }
                }

            }

            return result;
        }
    }
}
