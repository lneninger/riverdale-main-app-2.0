using ApplicationLogic.Business.Commands.Funza.CategoryPageQueryCommand.Models;
using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
using DomainModel.Funza;
using EntityFrameworkCore.DbContextScope;
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
    public class CategoryDBRepository : AbstractDBRepository, ICategoryDBRepository
    {
        public FunzaCategoryDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<CategoryReference>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<DomainModel.Funza.CategoryReference>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<DomainModel.Funza.CategoryReference>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Funza Categories", ex);
            }

            return result;
        }

        

        public OperationResponse<CategoryReference> GetById(int id)
        {
            var result = new OperationResponse<CategoryReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<CategoryReference>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Category {id}", ex);
            }

            return result;
        }

        public OperationResponse<CategoryReference> GetByFunzaId(int id)
        {
            var result = new OperationResponse<CategoryReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<CategoryReference>().Where(o => o.FunzaId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Category {id}", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<FunzaCategoryPageQueryCommandOutputDTO>> PageQuery(PageQuery<FunzaCategoryPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<FunzaCategoryPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<CategoryReference>();
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


                    var query = dbLocator.Set<CategoryReference>().AsQueryable();


                    var advancedSorting = new List<SortItem<CategoryReference>>();
                    Expression<Func<CategoryReference, object>> expression = null;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyCustomerId;
                    //    advancedSorting.Add(new SortItem<ColorReference> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<CategoryReference>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<CategoryReference, FunzaCategoryPageQueryCommandOutputDTO>(predicate, input, sorting, o => new FunzaCategoryPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name,
                        CreatedAt = o.CreatedAt
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting funza category page query", ex);
            }

            return result;
        }


        public OperationResponse Add(CategoryReference entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Funza Category", ex);
            }

            return result;
            
        }

    }
}
