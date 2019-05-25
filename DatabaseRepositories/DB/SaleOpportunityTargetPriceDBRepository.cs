using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.PageQueryCommand.Models;
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
    public class SaleOpportunityTargetPriceDBRepository : AbstractDBRepository, ISaleOpportunityTargetPriceDBRepository
    {
        public SaleOpportunityTargetPriceDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<SaleOpportunityTargetPrice>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<SaleOpportunityTargetPrice>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunityTargetPrice>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Product ", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<SaleOpportunityTargetPricePageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityTargetPricePageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<SaleOpportunityTargetPricePageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<SaleOpportunityTargetPrice>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.SaleOpportunityTargetPriceProducts.Any(sampleProductItem => sampleProductItem.Product.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase)));
                    }
                }

                var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    var query = dbLocator.Set<SaleOpportunityTargetPrice>().AsQueryable();

                    var advancedSorting = new List<SortItem<SaleOpportunityTargetPrice>>();
                    Expression<Func<SaleOpportunityTargetPrice, object>> expression;
                    if (input.Sort.ContainsKey("productType"))
                    {
                        expression = o => o.SaleOpportunityTargetPriceProducts.FirstOrDefault().Product.ProductType.Name;
                        advancedSorting.Add(new SortItem<SaleOpportunityTargetPrice> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<SaleOpportunityTargetPrice>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<SaleOpportunityTargetPrice, SaleOpportunityTargetPricePageQueryCommandOutputDTO>(predicate, input, sorting, o => new SaleOpportunityTargetPricePageQueryCommandOutputDTO
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

        public OperationResponse<SaleOpportunityTargetPrice> GetById(int id, bool forceRefresh = false)
        {
            var result = new OperationResponse<SaleOpportunityTargetPrice>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunityTargetPrice>().Find(id);//.FirstOrDefault();
                    if (forceRefresh && result.Bag != null)
                    {
                        this.Detach(result.Bag);
                        result.Bag = dbLocator.Set<SaleOpportunityTargetPrice>().Find(id);//.FirstOrDefault();

                    }
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box  {id}", ex);
            }

            return result;
        }

        public OperationResponse<SaleOpportunityTargetPrice> GetByIdWithProducts(int id)
        {
            var result = new OperationResponse<SaleOpportunityTargetPrice>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                result.Bag = dbLocator.Set<SaleOpportunityTargetPrice>().Include(t => t.SaleOpportunityTargetPriceProducts).Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box  {id}", ex);
            }

            return result;
        }



        public OperationResponse Insert(SaleOpportunityTargetPrice entity)
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

        public OperationResponse Delete(SaleOpportunityTargetPrice entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<SaleOpportunityTargetPrice>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Sample Box ", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(SaleOpportunityTargetPrice entity)
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
                    result.AddException("Error voiding Sample Box ", ex);
                }
            }

            return null;
        }


        public void Detach(int id)
        {
            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            {
                try
                {
                    var trackedEntity = dbLocator.ChangeTracker.Entries<SaleOpportunityTargetPrice>().FirstOrDefault(trackedItem => trackedItem.Entity.Id == id);
                    if (trackedEntity != null)
                    {
                        dbLocator.Entry<SaleOpportunityTargetPrice>(trackedEntity.Entity).State = EntityState.Detached;
                    }
                }
                catch (Exception ex)
                {
                }
            }

        }

    }
}
