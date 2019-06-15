using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.Funza.ColorPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using Framework.Core.Messages;
using DomainModel.Funza;

namespace DatabaseRepositories.DB
{
    public class FunzaColorDBRepository : AbstractDBRepository, IColorDBRepository
    {
        public FunzaColorDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<ColorReference>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<DomainModel.Funza.ColorReference>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<DomainModel.Funza.ColorReference>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Funza Colors", ex);
            }

            return result;
        }



        public OperationResponse<ColorReference> GetById(int id)
        {
            var result = new OperationResponse<ColorReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ColorReference>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Color {id}", ex);
            }

            return result;
        }

        public OperationResponse<ColorReference> GetByFunzaId(string id)
        {
            var result = new OperationResponse<ColorReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ColorReference>().Where(o => o.FunzaId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Color {id}", ex);
            }

            return result;
        }


        public OperationResponse<PageResult<FunzaColorPageQueryCommandOutputDTO>> PageQuery(PageQuery<FunzaColorPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<FunzaColorPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<ColorReference>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    //if (!string.IsNullOrWhiteSpace(filter.Term))
                    //{
                    //    predicate = predicate.And(o => o.ReferenceDescription.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    //}
                }

                var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {


                    var query = dbLocator.Set<ColorReference>().AsQueryable();


                    var advancedSorting = new List<SortItem<ColorReference>>();
                    Expression<Func<ColorReference, object>> expression = null;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyCustomerId;
                    //    advancedSorting.Add(new SortItem<ColorReference> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<ColorReference>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<ColorReference, FunzaColorPageQueryCommandOutputDTO>(predicate, input, sorting, o => new FunzaColorPageQueryCommandOutputDTO
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

        public OperationResponse Add(ColorReference entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
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
