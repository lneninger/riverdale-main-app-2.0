using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategory.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategory.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategory.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategory.InsertCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategory.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.ProductCategory.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using DomainModel._Commons.Enums;
using Framework.Core.Messages;
using DomainModel.Product;

namespace DatabaseRepositories.DB
{
    public class ProductCategoryDBRepository : AbstractDBRepository, IProductCategoryDBRepository
    {
        public ProductCategoryDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<ProductCategory>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<ProductCategory>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductCategory>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddError("Error GetAll ProductCategory", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<ProductCategoryPageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductCategoryPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<ProductCategoryPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<ProductCategory>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    var query = dbLocator.Set<ProductCategory>().AsQueryable();


                    var advancedSorting = new List<SortItem<ProductCategory>>();
                    //var advancedSorting = new List<Expression<Func<ProductCategory, object>>>();
                    //Expression<Func<ProductCategory, object>> expression;

                    var sorting = new SortingDTO<ProductCategory>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<ProductCategory, ProductCategoryPageQueryCommandOutputDTO>(predicate, input, sorting, o => new ProductCategoryPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name,
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting customer freightout page query", ex);
            }

            return result;
        }

        public OperationResponse<ProductCategory> GetById(string id)
        {
            var result = new OperationResponse<ProductCategory>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductCategory>().Where(o => o.Id == id).FirstOrDefault();//.Select(entityItem => new ProductCategoryGetByIdCommandOutputDTO
                    //{
                    //    Id = entityItem.Id,
                    //    Name = entityItem.Name,
                    //    HexCode = entityItem.HexCode,
                    //    IsBasicColor = entityItem.IsBasicColor,
                    //}).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error geting customer freightout {id}", ex);
            }

            return result;
        }

        public OperationResponse Insert(ProductCategory entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding customer freightout", ex);
            }

            return result;
        }

        //public OperationResponse Update(ProductCategory input)
        //{
        //    var result = new OperationResponse<ProductCategoryUpdateCommandOutputDTO>();
        //    try
        //    {
        //        var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
        //        {
        //            var entity = dbLocator.Set<ProductCategory>().FirstOrDefault(o => o.Id == input.Id);
        //            if (entity != null)
        //            {
                        
        //            }

                   
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.AddException($"Error updating customer freightout", ex);
        //    }

        //    return result;
        //}

        public OperationResponse Delete(ProductCategory entity)
        {
            var result = new OperationResponse();

            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                try
                {
                    dbLocator.Set<ProductCategory>().Remove(entity);
                }
                catch (Exception ex)
                {
                    result.AddException("Error deleting Product Color Type", ex);
                }
            }

            return null;

        }

        public OperationResponse<ProductCategoryDeleteCommandOutputDTO> LogicalDelete(ProductCategory entity)
        {
            var result = new OperationResponse<ProductCategoryDeleteCommandOutputDTO>();

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
