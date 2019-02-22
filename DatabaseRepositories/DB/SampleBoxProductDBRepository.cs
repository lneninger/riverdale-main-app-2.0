using ApplicationLogic.Business.Commands.SampleBoxProduct.PageQueryCommand.Models;
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
    public class SampleBoxProductDBRepository : AbstractDBRepository, ISampleBoxProductDBRepository
    {
        public SampleBoxProductDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<SampleBoxProduct>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<SampleBoxProduct>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SampleBoxProduct>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Sample Box's Product ", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<SampleBoxProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<SampleBoxProductPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<SampleBoxProductPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<SampleBoxProduct>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.SaleOpportunityPriceLevelProduct.Product.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    var query = dbLocator.Set<SampleBoxProduct>().AsQueryable();

                    var advancedSorting = new List<SortItem<SampleBoxProduct>>();
                    Expression<Func<AbstractProduct, object>> expression;
                    if (input.Sort.ContainsKey("productType"))
                    {
                        expression = o => o.ProductType.Name;
                        advancedSorting.Add(new SortItem<SampleBoxProduct> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<SampleBoxProduct>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<SampleBoxProduct, SampleBoxProductPageQueryCommandOutputDTO>(predicate, input, sorting, o => new SampleBoxProductPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        SampleBoxId = o.SampleBoxId,
                        SaleOpportunityPriceLevelProductId = o.SaleOpportunityPriceLevelProductId,
                        Order = o.Order
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box's Product  page query", ex);
            }

            return result;
        }

        public OperationResponse<SampleBoxProduct> GetById(int id, bool forceRefresh = false)
        {
            var result = new OperationResponse<SampleBoxProduct>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SampleBoxProduct>().Find(id);//.FirstOrDefault();
                    if (forceRefresh && result.Bag != null)
                    {
                        this.Detach(result.Bag);
                        result.Bag = dbLocator.Set<SampleBoxProduct>().Find(id);//.FirstOrDefault();

                    }
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box's Product  {id}", ex);
            }

            return result;
        }

        public OperationResponse<SampleBoxProduct> GetByIdWithMedias(int id)
        {
            var result = new OperationResponse<SampleBoxProduct>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                result.Bag = dbLocator.Set<SampleBoxProduct>()/*.Include(t => t.ProductMedias)*/.Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Sample Box's Product  {id}", ex);
            }

            return result;
        }



        public OperationResponse Insert(SampleBoxProduct entity)
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

        public OperationResponse Delete(SampleBoxProduct entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<SampleBoxProduct>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Sample Box's Product ", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(SampleBoxProduct entity)
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
                    var trackedEntity = dbLocator.ChangeTracker.Entries<SampleBoxProduct>().FirstOrDefault(trackedItem => trackedItem.Entity.Id == id);
                    if (trackedEntity != null)
                    {
                        dbLocator.Entry<SampleBoxProduct>(trackedEntity.Entity).State = EntityState.Detached;
                    }

                    //var entity = dbLocator.Find<SampleBoxProduct>(id);
                    //if (entity != null)
                    //{
                    //    dbLocator.Entry<SampleBoxProduct>(entity).State = EntityState.Detached;
                    //}
                }
                catch (Exception ex)
                {
                }
            }

        }

    }
}
