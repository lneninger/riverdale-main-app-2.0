using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.InsertCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.UpdateCommand.Models;
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
    public class ProductCategoryAllowedSizeDBRepository : AbstractDBRepository, IProductCategoryAllowedSizeDBRepository
    {
        public ProductCategoryAllowedSizeDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<ProductCategoryAllowedSize>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<ProductCategoryAllowedSize>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductCategoryAllowedSize>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Product Allowed Color Type", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<ProductCategoryAllowedSizePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductCategoryAllowedSizePageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<ProductCategoryAllowedSizePageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<ProductCategoryAllowedSize>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.ProductCategory.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    var query = dbLocator.Set<ProductCategoryAllowedSize>().AsQueryable();

                    var advancedSorting = new List<SortItem<ProductCategoryAllowedSize>>();
                    Expression<Func<ProductCategoryAllowedSize, object>> expression;
                    if (input.Sort.ContainsKey("product"))
                    {
                        expression = o => o.ProductCategory.Name;
                        advancedSorting.Add(new SortItem<ProductCategoryAllowedSize> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<ProductCategoryAllowedSize>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<ProductCategoryAllowedSize, ProductCategoryAllowedSizePageQueryCommandOutputDTO>(predicate, input, sorting, o => new ProductCategoryAllowedSizePageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        ProductCategoryName = o.ProductCategory.Name,
                        Size = o.Size,
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

        public OperationResponse<DomainModel.Product.ProductCategoryAllowedSize> GetById(int id)
        {
            var result = new OperationResponse<DomainModel.Product.ProductCategoryAllowedSize>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductCategoryAllowedSize>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Product Alowed Color type {id}", ex);
            }

            return result;
        }

       
        public OperationResponse Insert(ProductCategoryAllowedSize entity)
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

        public OperationResponse Delete(DomainModel.Product.ProductCategoryAllowedSize entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<ProductCategoryAllowedSize>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Product Color Type", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(ProductCategoryAllowedSize entity)
        {
            var result = new OperationResponse();

            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
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
