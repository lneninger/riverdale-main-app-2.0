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

        public OperationResponse<IEnumerable<ProductAllowedColorType>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<ProductAllowedColorType>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductAllowedColorType>().AsEnumerable();
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
                var predicate = PredicateBuilderExtension.True<ProductAllowedColorType>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.Product.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    var query = dbLocator.Set<ProductAllowedColorType>().AsQueryable();

                    var advancedSorting = new List<SortItem<ProductAllowedColorType>>();
                    Expression<Func<ProductAllowedColorType, object>> expression;
                    if (input.Sort.ContainsKey("product"))
                    {
                        expression = o => o.Product.Name;
                        advancedSorting.Add(new SortItem<ProductAllowedColorType> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<ProductAllowedColorType>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<ProductAllowedColorType, ProductAllowedColorTypePageQueryCommandOutputDTO>(predicate, input, sorting, o => new ProductAllowedColorTypePageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        ProductName = o.Product.Name,
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

        public OperationResponse<DomainModel.Product.ProductAllowedColorType> GetById(int id)
        {
            var result = new OperationResponse<DomainModel.Product.ProductAllowedColorType>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductAllowedColorType>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Product Alowed Color type {id}", ex);
            }

            return result;
        }

       
        public OperationResponse Insert(ProductAllowedColorType entity)
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

        public OperationResponse Delete(DomainModel.Product.ProductAllowedColorType entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<ProductAllowedColorType>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Product Color Type", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(ProductAllowedColorType entity)
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
