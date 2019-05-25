using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.InsertCommand.Models;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using Framework.Core.Messages;

using ApplicationLogic.Business.Commons.DTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using DomainModel._Commons.Enums;
using DomainModel.Product;

namespace DatabaseRepositories.DB
{
    public class ProductAllowedColorTypeDBRepository : AbstractDBRepository, IProductAllowedColorTypeDBRepository
    {
        public ProductAllowedColorTypeDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<ProductCategoryAllowedColorType>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<ProductCategoryAllowedColorType>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductCategoryAllowedColorType>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Product Allowed Color Type", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<ProductAllowedColorTypePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductAllowedColorTypePageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<ProductAllowedColorTypePageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<ProductCategoryAllowedColorType>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.ProductCategory.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    var query = dbLocator.Set<ProductCategoryAllowedColorType>().AsQueryable();

                    var advancedSorting = new List<SortItem<ProductCategoryAllowedColorType>>();
                    Expression<Func<ProductCategoryAllowedColorType, object>> expression;
                    if (input.Sort.ContainsKey("product"))
                    {
                        expression = o => o.ProductCategory.Name;
                        advancedSorting.Add(new SortItem<ProductCategoryAllowedColorType> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<ProductCategoryAllowedColorType>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<ProductCategoryAllowedColorType, ProductAllowedColorTypePageQueryCommandOutputDTO>(predicate, input, sorting, o => new ProductAllowedColorTypePageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        ProductName = o.ProductCategory.Name,
                        ProductColorTypeName = o.ProductColorType.Name,
                        CreatedAt = o.CreatedAt,
                       
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting customer page query", ex);
            }

            return result;
        }

        public OperationResponse<DomainModel.Product.ProductCategoryAllowedColorType> GetById(int id)
        {
            var result = new OperationResponse<DomainModel.Product.ProductCategoryAllowedColorType>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductCategoryAllowedColorType>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Product Alowed Color type {id}", ex);
            }

            return result;
        }

       
        public OperationResponse Insert(ProductCategoryAllowedColorType entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Product", ex);
            }

            return result;
        }

        public OperationResponse Delete(DomainModel.Product.ProductCategoryAllowedColorType entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<ProductCategoryAllowedColorType>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Product Color Type", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(ProductCategoryAllowedColorType entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            {
                try
                {
                    if (!(entity.IsDeleted ?? false))
                    {
                        entity.DeletedAt = DateTime.UtcNow;
                        dbLocator.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    result.AddException("Error voiding Product Color Type", ex);
                }
            }

            return null;
        }

    }
}
