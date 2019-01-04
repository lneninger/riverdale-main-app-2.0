using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunity.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunity.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunity.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunity.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.SaleOpportunity.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using Framework.Core.Messages;
using DomainModel.SaleOpportunity;
using ApplicationLogic.Business.Commons.DTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
//using ApplicationLogic.Business.Commands.SaleOpportunity.Commons;

namespace DatabaseRepositories.DB
{
    public class SaleOpportunityDBRepository : AbstractDBRepository, ISaleOpportunityDBRepository
    {
        public SaleOpportunityDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<SaleOpportunity>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<SaleOpportunity>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunity>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all SaleOpportunity", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<SaleOpportunityPageQueryCommandOutputDTO>> PageQuery(PageQuery<SaleOpportunityPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<SaleOpportunityPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<SaleOpportunity>();
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
                    var query = dbLocator.Set<SaleOpportunity>().AsQueryable();

                    var advancedSorting = new List<SortItem<SaleOpportunity>>();
                    Expression<Func<SaleOpportunity, object>> expression;
                    if (input.Sort.ContainsKey("SaleSeasonType"))
                    {
                        expression = o => o.SaleSeasonType.Name;
                        advancedSorting.Add(new SortItem<SaleOpportunity> { PropertyName = "SaleOpportunityType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<SaleOpportunity>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<SaleOpportunity, SaleOpportunityPageQueryCommandOutputDTO>(predicate, input, sorting, o => new SaleOpportunityPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name,
                        SaleSeasonTypeId = o.SaleSeasonTypeId,
                        SaleSeasonTypeName = o.SaleSeasonType.Name,
                        CustomerId = o.CustomerId,
                        CustomerName = o.Customer.Name,
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

        public OperationResponse<DomainModel.SaleOpportunity.SaleOpportunity> GetById(int id)
        {
            var result = new OperationResponse<DomainModel.SaleOpportunity.SaleOpportunity>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<SaleOpportunity>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting SaleOpportunity {id}", ex);
            }

            return result;
        }

        public OperationResponse<DomainModel.SaleOpportunity.SaleOpportunity> GetByIdWithProducts(int id)
        {
            var result = new OperationResponse<DomainModel.SaleOpportunity.SaleOpportunity>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                result.Bag = dbLocator.Set<SaleOpportunity>()/*.Include(t => t.SaleOpportunityMedias)*/.Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting SaleOpportunity {id}", ex);
            }

            return result;
        }



        public OperationResponse Insert(SaleOpportunity entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding SaleOpportunity", ex);
            }

            return result;
        }

        //public OperationResponse<SaleOpportunityUpdateCommandOutputDTO> Update(SaleOpportunityUpdateCommandInputDTO input)
        //{
        //    var result = new OperationResponse<SaleOpportunityUpdateCommandOutputDTO>();
        //    var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
        //    {
        //        var entity = dbLocator.Set<SaleOpportunity>().FirstOrDefault(o => o.Id == input.Id);
        //        if (entity != null)
        //        {
        //            entity.Name = input.Name;
        //        }

        //        dbLocator.SaveChanges();


        //        var dbResult = dbLocator.Set<SaleOpportunity>().Where(o => o.Id == entity.Id).Select(o => new SaleOpportunityUpdateCommandOutputDTO
        //        {
        //            Id = o.Id,
        //            Name = o.Name
        //        }).FirstOrDefault();

        //        result.Bag = dbResult;
        //        return result;
        //    }
        //}

        public OperationResponse Delete(DomainModel.SaleOpportunity.SaleOpportunity entity)
        {
            var result = new OperationResponse();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<SaleOpportunity>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting SaleOpportunity", ex);
            }

            return null;
        }

        public OperationResponse LogicalDelete(SaleOpportunity entity)
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
                    result.AddException("Error voiding SaleOpportunity Color Type", ex);
                }
            }

            return null;
        }

    }
}
