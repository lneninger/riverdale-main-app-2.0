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
using FunzaApplicationLogic.Commands.ColorPageQueryCommand.Models;

namespace DatabaseRepositories.DB
{
    public class FunzaColorDBRepository : AbstractDBRepository, IColorDBRepository
    {
        public FunzaColorDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
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



        public OperationResponse<Color> GetById(int id)
        {
            var result = new OperationResponse<Color>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<Color>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Color {id}", ex);
            }

            return result;
        }

        public OperationResponse<Color> GetByFunzaId(string id)
        {
            var result = new OperationResponse<Color>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<Color>().Where(o => o.FunzaId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Color {id}", ex);
            }

            return result;
        }


        public OperationResponse<PageResult<ColorPageQueryCommandOutput>> PageQuery(PageQuery<ColorPageQueryCommandInput> input)
        {
            var result = new OperationResponse<PageResult<ColorPageQueryCommandOutput>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<Color>();
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


                    var query = dbLocator.Set<Color>().AsQueryable();


                    var advancedSorting = new List<SortItem<Color>>();
                    Expression<Func<Color, object>> expression = null;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyCustomerId;
                    //    advancedSorting.Add(new SortItem<Color> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<Color>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<Color, ColorPageQueryCommandOutput>(predicate, input, sorting, o => new ColorPageQueryCommandOutput
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

        public OperationResponse Add(Color entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Funza Color", ex);
            }

            return result;

        }

    }
}
