using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.PageQueryCommand.Models;
using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
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
    public class SaleOpportunityPriceLevelDBRepository : AbstractDBRepository, ISaleOpportunityPriceLevelDBRepository
    {
        public SaleOpportunityPriceLevelDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<SaleOpportunityPriceLevel>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<SaleOpportunityPriceLevel>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunityPriceLevel>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Product ", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<SaleOpportunityPriceLevelPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityPriceLevelPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<SaleOpportunityPriceLevelPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<SaleOpportunityPriceLevel>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.SaleOpportunityPriceLevelProducts.Any(sampleProductItem => sampleProductItem.Product.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase)));
                    }
                }

                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    var query = dbLocator.Set<SaleOpportunityPriceLevel>().AsQueryable();

                    var advancedSorting = new List<SortItem<SaleOpportunityPriceLevel>>();
                    Expression<Func<SaleOpportunityPriceLevel, object>> expression;
                    if (input.Sort.ContainsKey("productType"))
                    {
                        expression = o => o.SaleOpportunityPriceLevelProducts.FirstOrDefault().Product.ProductType.Name;
                        advancedSorting.Add(new SortItem<SaleOpportunityPriceLevel> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<SaleOpportunityPriceLevel>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<SaleOpportunityPriceLevel, SaleOpportunityPriceLevelPageQueryCommandOutputDTO>(predicate, input, sorting, o => new SaleOpportunityPriceLevelPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        SaleSeasonTypeId = o.SaleSeasonTypeId,

                        TargetPrice = o.TargetPrice
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box  page query", ex);
            }

            return result;
        }

        public OperationResponse<SaleOpportunityPriceLevel> GetById(int id)
        {
            var result = new OperationResponse<SaleOpportunityPriceLevel>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunityPriceLevel>().Find(id);//.FirstOrDefault();
                    //if (forceRefresh && result.Bag != null)
                    //{
                    //    this.Detach(result.Bag);
                    //    result.Bag = dbLocator.Set<SaleOpportunityPriceLevel>().Find(id);//.FirstOrDefault();

                    //}
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box  {id}", ex);
            }

            return result;
        }

        public OperationResponse<SaleOpportunityPriceLevel> GetByIdWithProducts(int id)
        {
            var result = new OperationResponse<SaleOpportunityPriceLevel>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                result.Bag = dbLocator.Set<SaleOpportunityPriceLevel>().Include(t => t.SaleOpportunityPriceLevelProducts).Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box  {id}", ex);
            }

            return result;
        }



        public OperationResponse Insert(SaleOpportunityPriceLevel entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Sample Box ", ex);
            }

            return result;
        }

        public OperationResponse Delete(SaleOpportunityPriceLevel entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<SaleOpportunityPriceLevel>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Sample Box ", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(SaleOpportunityPriceLevel entity)
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
                    result.AddException("Error voiding Sample Box ", ex);
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
                    var trackedEntity = dbLocator.ChangeTracker.Entries<SaleOpportunityPriceLevel>().FirstOrDefault(trackedItem => trackedItem.Entity.Id == id);
                    if (trackedEntity != null)
                    {
                        dbLocator.Entry<SaleOpportunityPriceLevel>(trackedEntity.Entity).State = EntityState.Detached;
                    }
                }
                catch (Exception ex)
                {
                }
            }

        }

    }
}
