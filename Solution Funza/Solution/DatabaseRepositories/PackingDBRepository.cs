using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using Framework.Core.Messages;
using FunzaApplicationLogic.Commands.Funza.PackingPageQueryCommand.Models;

namespace DatabaseRepositories.DB
{
    public class FunzaPackingDBRepository : AbstractDBRepository, IPackingDBRepository
    {
        public FunzaPackingDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<Color>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<DomainModel.Color>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<DomainModel.Color>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Funza Colors", ex);
            }

            return result;
        }

        

        public OperationResponse<Packing> GetById(int id)
        {
            var result = new OperationResponse<Packing>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<Packing>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Packing {id}", ex);
            }

            return result;
        }

        public OperationResponse<Packing> GetByFunzaId(int id)
        {
            var result = new OperationResponse<Packing>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<Packing>().Where(o => o.FunzaId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Packing {id}", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<PackingPageQueryCommandOutput>> PageQuery(PageQuery<PackingPageQueryCommandInput> input)
        {
            var result = new OperationResponse<PageResult<PackingPageQueryCommandOutput>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<Packing>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    //if (!string.IsNullOrWhiteSpace(filter.Term))
                    //{
                    //    predicate = predicate.And(o => o.ReferenceDescription.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    //}
                }

                var dbLocator = this.AmbientDbContextLocator.Get<FunzaDBContext>();
                {


                    var query = dbLocator.Set<Packing>().AsQueryable();


                    var advancedSorting = new List<SortItem<Packing>>();
                    Expression<Func<Packing, object>> expression = null;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyCustomerId;
                    //    advancedSorting.Add(new SortItem<Packing> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<Packing>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<Packing, PackingPageQueryCommandOutput>(predicate, input, sorting, o => new PackingPageQueryCommandOutput
                    {
                        Id = o.Id,
                        Name = o.Name,
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


        public OperationResponse Add(Packing entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Funza Packing", ex);
            }

            return result;
            
        }

    }
}
