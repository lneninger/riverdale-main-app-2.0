using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.FlowerProductCategory.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel.Product;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.GetByIdCommand
{
    public class FlowerProductCategoryGetByIdCommand : AbstractDBCommand<DomainModel.Product.FlowerProductCategory, IFlowerProductCategoryDBRepository>, IFlowerProductCategoryGetByIdCommand
    {

        public FlowerProductCategoryGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IFlowerProductCategoryDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FlowerProductCategoryGetByIdCommandOutputDTO> Execute(string id)
        {
            var result = new OperationResponse<FlowerProductCategoryGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    
                    result.Bag = new FlowerProductCategoryGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,
                        //Medias = getByIdResult.Bag.FlowerProductCategoryMedias.Select(m => new FileItemRefOutputDTO
                        //{
                        //    Id = m.Id,
                        //    FileId = m.FileRepositoryId,
                        //    FullUrl = m.FileRepository.FullFilePath
                        //}).ToList(),
                        FlowerProductCategoryAllowedColorTypes = getByIdResult.Bag.AllowedColorTypes.Select(m => new FlowerProductCategoryGetByIdCommandOutputAllowedColorTypeItemDTO
                        {
                            Id = m.Id,
                            FlowerProductCategoryColorTypeId = m.ProductColorTypeId,
                        }).ToList()
                    };

                    
                }
            }

            return result;



        }
    }
}
