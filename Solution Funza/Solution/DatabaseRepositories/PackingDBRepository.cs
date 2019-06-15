using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
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
    public class FunzaPackingDBRepository : AbstractDBRepository, IPackingDBRepository
    {
        public FunzaPackingDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
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

        

        public OperationResponse<PackingReference> GetById(int id)
        {
            var result = new OperationResponse<PackingReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<PackingReference>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Packing {id}", ex);
            }

            return result;
        }

        public OperationResponse<PackingReference> GetByFunzaId(int id)
        {
            var result = new OperationResponse<PackingReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<PackingReference>().Where(o => o.FunzaId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Packing {id}", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<FunzaPackingPageQueryCommandOutputDTO>> PageQuery(PageQuery<FunzaPackingPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<FunzaPackingPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<PackingReference>();
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


                    var query = dbLocator.Set<PackingReference>().AsQueryable();


                    var advancedSorting = new List<SortItem<PackingReference>>();
                    Expression<Func<PackingReference, object>> expression = null;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyCustomerId;
                    //    advancedSorting.Add(new SortItem<PackingReference> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<PackingReference>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<PackingReference, FunzaPackingPageQueryCommandOutputDTO>(predicate, input, sorting, o => new FunzaPackingPageQueryCommandOutputDTO
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


        public OperationResponse Add(PackingReference entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
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
