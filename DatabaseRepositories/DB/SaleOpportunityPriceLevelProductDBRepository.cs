using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.PageQueryCommand.Models;
using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
using DomainModel.Product;
using DomainModel.SaleOpportunity;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DatabaseRepositories.DB
{
    public class SaleOpportunityPriceLevelProductDBRepository : AbstractDBRepository, ISaleOpportunityPriceLevelProductDBRepository
    {
        public SaleOpportunityPriceLevelProductDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<SaleOpportunityPriceLevelProduct>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<SaleOpportunityPriceLevelProduct>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunityPriceLevelProduct>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Sample Box's Product ", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<SaleOpportunityPriceLevelProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityPriceLevelProductPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<SaleOpportunityPriceLevelProductPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<SaleOpportunityPriceLevelProduct>();
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
                    var query = dbLocator.Set<SaleOpportunityPriceLevelProduct>().AsQueryable();

                    var advancedSorting = new List<SortItem<SaleOpportunityPriceLevelProduct>>();
                    Expression<Func<AbstractProduct, object>> expression;
                    if (input.Sort.ContainsKey("productType"))
                    {
                        expression = o => o.ProductType.Name;
                        advancedSorting.Add(new SortItem<SaleOpportunityPriceLevelProduct> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<SaleOpportunityPriceLevelProduct>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<SaleOpportunityPriceLevelProduct, SaleOpportunityPriceLevelProductPageQueryCommandOutputDTO>(predicate, input, sorting, o => new SaleOpportunityPriceLevelProductPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        SaleOpportunityPriceLevelId = o.SaleOpportunityPriceLevelId,
                        ProductId = o.ProductId,
                        ProductAmount = o.ProductAmount
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box's Product  page query", ex);
            }

            return result;
        }

        public OperationResponse<SaleOpportunityPriceLevelProduct> GetById(int id, bool forceRefresh = false)
        {
            var result = new OperationResponse<SaleOpportunityPriceLevelProduct>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunityPriceLevelProduct>().Find(id);//.FirstOrDefault();
                    if (forceRefresh && result.Bag != null)
                    {
                        this.Detach(result.Bag);
                        result.Bag = dbLocator.Set<SaleOpportunityPriceLevelProduct>().Find(id);//.FirstOrDefault();

                    }
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box's Product  {id}", ex);
            }

            return result;
        }

        public OperationResponse<SaleOpportunityPriceLevelProduct> GetByIdWithMedias(int id)
        {
            var result = new OperationResponse<SaleOpportunityPriceLevelProduct>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                result.Bag = dbLocator.Set<SaleOpportunityPriceLevelProduct>()/*.Include(t => t.ProductMedias)*/.Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box's Product  {id}", ex);
            }

            return result;
        }



        public OperationResponse Insert(SaleOpportunityPriceLevelProduct entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Sample Box's Product ", ex);
            }

            return result;
        }

        public OperationResponse Delete(SaleOpportunityPriceLevelProduct entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<SaleOpportunityPriceLevelProduct>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Sample Box's Product ", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(SaleOpportunityPriceLevelProduct entity)
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
                    result.AddException("Error voiding Sample Box's Product ", ex);
                }
            }

            return null;
        }


        public void Detach(int id)
        {
            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                try
                {
                    var trackedEntity = dbLocator.ChangeTracker.Entries<SaleOpportunityPriceLevelProduct>().FirstOrDefault(trackedItem => trackedItem.Entity.Id == id);
                    if (trackedEntity != null)
                    {
                        dbLocator.Entry<SaleOpportunityPriceLevelProduct>(trackedEntity.Entity).State = EntityState.Detached;
                    }

                    //var entity = dbLocator.Find<SaleOpportunityPriceLevelProduct>(id);
                    //if (entity != null)
                    //{
                    //    dbLocator.Entry<SaleOpportunityPriceLevelProduct>(entity).State = EntityState.Detached;
                    //}
                }
                catch (Exception ex)
                {
                }
            }

        }

    }
}
