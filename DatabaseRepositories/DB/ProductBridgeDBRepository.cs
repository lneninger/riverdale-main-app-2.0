using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductBridge.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.ProductBridge.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.ProductBridge.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.ProductBridge.InsertCommand.Models;
using ApplicationLogic.Business.Commands.ProductBridge.UpdateCommand.Models;
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
using ApplicationLogic.Business.Commands.ProductBridge.PageQueryCommand.Models;

namespace DatabaseRepositories.DB
{
    public class ProductBridgeDBRepository : AbstractDBRepository, IProductBridgeDBRepository
    {
        public ProductBridgeDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<CompositionProductBridge>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<CompositionProductBridge>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<CompositionProductBridge>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Product Bridge", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<ProductBridgePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductBridgePageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<ProductBridgePageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<CompositionProductBridge>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.CompositionProduct.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    var query = dbLocator.Set<CompositionProductBridge>().AsQueryable();

                    var advancedSorting = new List<SortItem<CompositionProductBridge>>();
                    Expression<Func<AbstractProduct, object>> expression;
                    if (input.Sort.ContainsKey("productType"))
                    {
                        expression = o => o.ProductType.Name;
                        advancedSorting.Add(new SortItem<CompositionProductBridge> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<CompositionProductBridge>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<CompositionProductBridge, ProductBridgePageQueryCommandOutputDTO>(predicate, input, sorting, o => new ProductBridgePageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        ProductId = o.CompositionProductId,
                        RelatedProductId = o.CompositionItemId,
                        Stems = o.Stems
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Product Bridge page query", ex);
            }

            return result;
        }

        public OperationResponse<CompositionProductBridge> GetById(int id, bool forceRefresh = false)
        {
            var result = new OperationResponse<CompositionProductBridge>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<CompositionProductBridge>().Find(id);//.FirstOrDefault();
                    if (forceRefresh && result.Bag != null)
                    {
                        this.Detach(result.Bag);
                        result.Bag = dbLocator.Set<CompositionProductBridge>().Find(id);//.FirstOrDefault();

                    }
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Product Bridge {id}", ex);
            }

            return result;
        }

        public OperationResponse<CompositionProductBridge> GetByIdWithMedias(int id)
        {
            var result = new OperationResponse<CompositionProductBridge>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                result.Bag = dbLocator.Set<CompositionProductBridge>()/*.Include(t => t.ProductMedias)*/.Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Product Bridge {id}", ex);
            }

            return result;
        }



        public OperationResponse Insert(CompositionProductBridge entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Product Bridge", ex);
            }

            return result;
        }

        public OperationResponse Delete(CompositionProductBridge entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<CompositionProductBridge>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Product Bridge", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(CompositionProductBridge entity)
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
                    result.AddException("Error voiding Product Bridge", ex);
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
                    var trackedEntity = dbLocator.ChangeTracker.Entries<CompositionProductBridge>().FirstOrDefault(trackedItem => trackedItem.Entity.Id == id);
                    if (trackedEntity != null)
                    {
                        dbLocator.Entry<CompositionProductBridge>(trackedEntity.Entity).State = EntityState.Detached;
                    }

                    //var entity = dbLocator.Find<CompositionProductBridge>(id);
                    //if (entity != null)
                    //{
                    //    dbLocator.Entry<CompositionProductBridge>(entity).State = EntityState.Detached;
                    //}
                }
                catch (Exception ex)
                {
                }
            }

        }

    }
}
