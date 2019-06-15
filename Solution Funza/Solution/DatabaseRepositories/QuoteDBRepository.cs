using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;

using System;
using System.Collections.Generic;
using System.Linq;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using Framework.Core.Messages;
using FunzaApplicationLogic.Commands.Funza.QuotePageQueryCommand.Models;

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
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<DomainModel.Quote>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Funza Quotes", ex);
            }

            return result;
        }

        

        public OperationResponse<Quote> GetById(int id)
        {
            var result = new OperationResponse<Quote>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<Quote>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Quote {id}", ex);
            }

            return result;
        }

        public OperationResponse<Quote> GetByFunzaId(int id)
        {
            var result = new OperationResponse<Quote>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<Quote>().Where(o => o.FunzaId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Quote {id}", ex);
            }

            return result;
        }


        public OperationResponse<PageResult<QuotePageQueryCommandOutput>> PageQuery(PageQuery<QuotePageQueryCommandInput> input)
        {
            var result = new OperationResponse<PageResult<QuotePageQueryCommandOutput>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<Quote>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.Title.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                var dbLocator = this.AmbientDbContextLocator.Get<FunzaDBContext>();
                {


                    var query = dbLocator.Set<Quote>().AsQueryable();


                    var advancedSorting = new List<SortItem<Quote>>();
                    Expression<Func<Quote, object>> expression = null;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyCustomerId;
                    //    advancedSorting.Add(new SortItem<Quote> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<Quote>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<Quote, QuotePageQueryCommandOutput>(predicate, input, sorting, o => new QuotePageQueryCommandOutput
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

        public OperationResponse Add(Quote entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
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
