using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBox.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SampleBox.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SampleBox.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SampleBox.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SampleBox.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.SampleBox.PageQueryCommand.Models;
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
using ApplicationLogic.Business.Commands.SampleBox.PageQueryCommand.Models;
using DomainModel.SaleOpportunity;

namespace DatabaseRepositories.DB
{
    public class SampleBoxDBRepository : AbstractDBRepository, ISampleBoxDBRepository
    {
        public SampleBoxDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<SampleBox>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<SampleBox>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SampleBox>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Product ", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<SampleBoxPageQueryCommandOutputDTO>> PageQuery(PageQuery<SampleBoxPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<SampleBoxPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<SampleBox>();
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
                    var query = dbLocator.Set<SampleBox>().AsQueryable();

                    var advancedSorting = new List<SortItem<SampleBox>>();
                    Expression<Func<AbstractProduct, object>> expression;
                    if (input.Sort.ContainsKey("productType"))
                    {
                        expression = o => o.ProductType.Name;
                        advancedSorting.Add(new SortItem<SampleBox> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<SampleBox>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<SampleBox, SampleBoxPageQueryCommandOutputDTO>(predicate, input, sorting, o => new SampleBoxPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        SampleBoxId = o.SampleBoxId,
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

        public OperationResponse<SampleBox> GetById(int id, bool forceRefresh = false)
        {
            var result = new OperationResponse<SampleBox>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SampleBox>().Find(id);//.FirstOrDefault();
                    if (forceRefresh && result.Bag != null)
                    {
                        this.Detach(result.Bag);
                        result.Bag = dbLocator.Set<SampleBox>().Find(id);//.FirstOrDefault();

                    }
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Product  {id}", ex);
            }

            return result;
        }

        public OperationResponse<SampleBox> GetByIdWithMedias(int id)
        {
            var result = new OperationResponse<SampleBox>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                result.Bag = dbLocator.Set<SampleBox>()/*.Include(t => t.ProductMedias)*/.Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Product  {id}", ex);
            }

            return result;
        }



        public OperationResponse Insert(SampleBox entity)
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

        public OperationResponse Delete(SampleBox entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<SampleBox>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Product ", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(SampleBox entity)
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
                    var trackedEntity = dbLocator.ChangeTracker.Entries<SampleBox>().FirstOrDefault(trackedItem => trackedItem.Entity.Id == id);
                    if (trackedEntity != null)
                    {
                        dbLocator.Entry<SampleBox>(trackedEntity.Entity).State = EntityState.Detached;
                    }

                    //var entity = dbLocator.Find<SampleBox>(id);
                    //if (entity != null)
                    //{
                    //    dbLocator.Entry<SampleBox>(entity).State = EntityState.Detached;
                    //}
                }
                catch (Exception ex)
                {
                }
            }

        }

    }
}
