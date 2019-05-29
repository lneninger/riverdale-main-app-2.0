using ApplicationLogic.Business.Commands.Grower.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Grower.PageQueryCommand.Models;
using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
using DomainModel._Commons.Enums;
using DomainModel.Company.Grower;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DatabaseRepositories.DB
{
    public class GrowerDBRepository : AbstractDBRepository, IGrowerDBRepository
    {
        public GrowerDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<Grower>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<Grower>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<Grower>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Grower", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<GrowerPageQueryCommandOutputDTO>> PageQuery(PageQuery<GrowerPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<GrowerPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<Grower>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {


                    var query = dbLocator.Set<Grower>().AsQueryable();


                    var advancedSorting = new List<SortItem<Grower>>();
                    Expression<Func<Grower, object>> expression;
                    if (input.Sort.ContainsKey("growerTypeId"))
                    {
                        expression = o => o.GrowerType.Name;
                        advancedSorting.Add(new SortItem<Grower> { PropertyName = "growerTypeId", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<Grower>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<Grower, GrowerPageQueryCommandOutputDTO>(predicate, input, sorting, o => new GrowerPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name,
                        CreatedAt = o.CreatedAt
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Grower page query", ex);
            }

            return result;
        }

        public OperationResponse<Grower> GetById(int id)
        {
            var result = new OperationResponse<Grower>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                result.Bag = dbLocator.Set<Grower>().Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Grower {id}", ex);
            }

            return result;
        }

        public OperationResponse Insert(Grower entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Grower", ex);
            }

            return result;

        }

        //public OperationResponse<GrowerUpdateCommandOutputDTO> Update(GrowerUpdateCommandInputDTO input)
        //{
        //    var result = new OperationResponse<GrowerUpdateCommandOutputDTO>();
        //    var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
        //    {
        //        var entity = dbLocator.Set<Grower>().FirstOrDefault(o => o.Id == input.Id);
        //        if (entity != null)
        //        {
        //            entity.Name = input.Name;
        //        }

        //        dbLocator.SaveChanges();


        //        var dbResult = dbLocator.Set<Grower>().Where(o => o.Id == entity.Id).Select(o => new GrowerUpdateCommandOutputDTO
        //        {
        //            Id = o.Id,
        //            Name = o.Name
        //        }).FirstOrDefault();

        //        result.Bag = dbResult;
        //        return result;
        //    }
        //}

        public OperationResponse<GrowerDeleteCommandOutputDTO> Delete(Grower entity)
        {
            var result = new OperationResponse<GrowerDeleteCommandOutputDTO>();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<Grower>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Grower", ex);
            }

            return null;
        }

        public OperationResponse<GrowerDeleteCommandOutputDTO> LogicalDelete(Grower entity)
        {
            var result = new OperationResponse<GrowerDeleteCommandOutputDTO>();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
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
                result.AddException("Error voiding Grower", ex);
            }

            return null;
        }


    }
}
