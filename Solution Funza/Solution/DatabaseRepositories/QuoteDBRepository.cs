using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.Funza.QuotePageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using DomainModel._Commons.Enums;
using Framework.Core.Messages;
using DomainModel.Funza;

namespace DatabaseRepositories.DB
{
    public class FunzaQuoteDBRepository : AbstractDBRepository, IQuoteDBRepository
    {
        public FunzaQuoteDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<Quote>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<DomainModel.Quote>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<DomainModel.Funza.QuoteReference>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Funza Quotes", ex);
            }

            return result;
        }

        

        public OperationResponse<QuoteReference> GetById(int id)
        {
            var result = new OperationResponse<QuoteReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<QuoteReference>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Quote {id}", ex);
            }

            return result;
        }

        public OperationResponse<QuoteReference> GetByFunzaId(int id)
        {
            var result = new OperationResponse<QuoteReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<QuoteReference>().Where(o => o.FunzaId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Quote {id}", ex);
            }

            return result;
        }


        public OperationResponse<PageResult<FunzaQuotePageQueryCommandOutputDTO>> PageQuery(PageQuery<FunzaQuotePageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<FunzaQuotePageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<QuoteReference>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.Title.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {


                    var query = dbLocator.Set<QuoteReference>().AsQueryable();


                    var advancedSorting = new List<SortItem<QuoteReference>>();
                    Expression<Func<QuoteReference, object>> expression = null;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyCustomerId;
                    //    advancedSorting.Add(new SortItem<QuoteReference> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<QuoteReference>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<QuoteReference, FunzaQuotePageQueryCommandOutputDTO>(predicate, input, sorting, o => new FunzaQuotePageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        Title = o.Title,
                        CreatedAt = o.CreatedAt
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting customer page query", ex);
            }

            return result;
        }

        public OperationResponse Add(QuoteReference entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Funza Quote", ex);
            }

            return result;
            
        }

    }
}
