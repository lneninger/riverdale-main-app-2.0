using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.PageQueryCommand.Models;
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
    public class SaleOpportunityTargetPriceProductDBRepository : AbstractDBRepository, ISaleOpportunityTargetPriceProductDBRepository
    {
        public SaleOpportunityTargetPriceProductDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<SaleOpportunityTargetPriceProduct>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<SaleOpportunityTargetPriceProduct>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunityTargetPriceProduct>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Sample Box's Product ", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<SaleOpportunityTargetPriceProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityTargetPriceProductPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<SaleOpportunityTargetPriceProductPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<SaleOpportunityTargetPriceProduct>();
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
                    var query = dbLocator.Set<SaleOpportunityTargetPriceProduct>().AsQueryable();

                    var advancedSorting = new List<SortItem<SaleOpportunityTargetPriceProduct>>();
                    Expression<Func<AbstractProduct, object>> expression;
                    if (input.Sort.ContainsKey("productType"))
                    {
                        expression = o => o.ProductType.Name;
                        advancedSorting.Add(new SortItem<SaleOpportunityTargetPriceProduct> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<SaleOpportunityTargetPriceProduct>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<SaleOpportunityTargetPriceProduct, SaleOpportunityTargetPriceProductPageQueryCommandOutputDTO>(predicate, input, sorting, o => new SaleOpportunityTargetPriceProductPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        TargetPriceId = o.SaleOpportunityTargetPriceId,
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

        public OperationResponse<SaleOpportunityTargetPriceProduct> GetById(int id, bool forceRefresh = false)
        {
            var result = new OperationResponse<SaleOpportunityTargetPriceProduct>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunityTargetPriceProduct>().Find(id);//.FirstOrDefault();
                    if (forceRefresh && result.Bag != null)
                    {
                        this.Detach(result.Bag);
                        result.Bag = dbLocator.Set<SaleOpportunityTargetPriceProduct>().Find(id);//.FirstOrDefault();

                    }
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box's Product  {id}", ex);
            }

            return result;
        }

        public OperationResponse<SaleOpportunityTargetPriceProduct> GetByIdWithMedias(int id)
        {
            var result = new OperationResponse<SaleOpportunityTargetPriceProduct>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                result.Bag = dbLocator.Set<SaleOpportunityTargetPriceProduct>()/*.Include(t => t.ProductMedias)*/.Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box's Product  {id}", ex);
            }

            return result;
        }



        public OperationResponse Insert(SaleOpportunityTargetPriceProduct entity)
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

        public OperationResponse Delete(SaleOpportunityTargetPriceProduct entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<SaleOpportunityTargetPriceProduct>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Sample Box's Product ", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(SaleOpportunityTargetPriceProduct entity)
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
                    var trackedEntity = dbLocator.ChangeTracker.Entries<SaleOpportunityTargetPriceProduct>().FirstOrDefault(trackedItem => trackedItem.Entity.Id == id);
                    if (trackedEntity != null)
                    {
                        dbLocator.Entry<SaleOpportunityTargetPriceProduct>(trackedEntity.Entity).State = EntityState.Detached;
                    }

                    //var entity = dbLocator.Find<SaleOpportunityTargetPriceProduct>(id);
                    //if (entity != null)
                    //{
                    //    dbLocator.Entry<SaleOpportunityTargetPriceProduct>(entity).State = EntityState.Detached;
                    //}
                }
                catch (Exception ex)
                {
                }
            }

        }

    }
}
