using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Product.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Product.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.Product.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.Product.InsertCommand.Models;
using ApplicationLogic.Business.Commands.Product.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.Product.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using Framework.Core.Messages;
using DomainModel.Product;
using ApplicationLogic.Business.Commons.DTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ApplicationLogic.Business.Commands.Product.PageQueryCommand.Models;
using DomainModel.SaleOpportunity;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.PageQueryCommand.Models;

namespace DatabaseRepositories.DB
{
    public class SaleOpportunityProductDBRepository : AbstractDBRepository, ISaleOpportunityProductDBRepository
    {
        public SaleOpportunityProductDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<SaleOpportunityProduct>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<SaleOpportunityProduct>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunityProduct>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Product ", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<SaleOpportunityProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityProductPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<SaleOpportunityProductPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<SaleOpportunityProduct>();
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
                    var query = dbLocator.Set<SaleOpportunityProduct>().AsQueryable();

                    var advancedSorting = new List<SortItem<SaleOpportunityProduct>>();
                    Expression<Func<AbstractProduct, object>> expression;
                    if (input.Sort.ContainsKey("productType"))
                    {
                        expression = o => o.ProductType.Name;
                        advancedSorting.Add(new SortItem<SaleOpportunityProduct> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<SaleOpportunityProduct>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<SaleOpportunityProduct, SaleOpportunityProductPageQueryCommandOutputDTO>(predicate, input, sorting, o => new SaleOpportunityProductPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        SaleOpportunityId = o.SaleOpportunityId,
                        ProductId = o.ProductId,
                        ProductAmount = o.ProductAmount
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Product  page query", ex);
            }

            return result;
        }

        public OperationResponse<SaleOpportunityProduct> GetById(int id, bool forceRefresh = false)
        {
            var result = new OperationResponse<SaleOpportunityProduct>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunityProduct>().Find(id);//.FirstOrDefault();
                    if (forceRefresh && result.Bag != null)
                    {
                        this.Detach(result.Bag);
                        result.Bag = dbLocator.Set<SaleOpportunityProduct>().Find(id);//.FirstOrDefault();

                    }
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Product  {id}", ex);
            }

            return result;
        }

        public OperationResponse<SaleOpportunityProduct> GetByIdWithMedias(int id)
        {
            var result = new OperationResponse<SaleOpportunityProduct>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                result.Bag = dbLocator.Set<SaleOpportunityProduct>()/*.Include(t => t.ProductMedias)*/.Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Product  {id}", ex);
            }

            return result;
        }



        public OperationResponse Insert(SaleOpportunityProduct entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Product ", ex);
            }

            return result;
        }

        public OperationResponse Delete(SaleOpportunityProduct entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<SaleOpportunityProduct>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Product ", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(SaleOpportunityProduct entity)
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
                    result.AddException("Error voiding Product ", ex);
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
                    var trackedEntity = dbLocator.ChangeTracker.Entries<SaleOpportunityProduct>().FirstOrDefault(trackedItem => trackedItem.Entity.Id == id);
                    if (trackedEntity != null)
                    {
                        dbLocator.Entry<SaleOpportunityProduct>(trackedEntity.Entity).State = EntityState.Detached;
                    }

                    //var entity = dbLocator.Find<SaleOpportunityProduct>(id);
                    //if (entity != null)
                    //{
                    //    dbLocator.Entry<SaleOpportunityProduct>(entity).State = EntityState.Detached;
                    //}
                }
                catch (Exception ex)
                {
                }
            }

        }

    }
}
