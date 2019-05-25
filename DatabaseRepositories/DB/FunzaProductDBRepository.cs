using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.Funza.ProductPageQueryCommand.Models;
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
    public class FunzaProductDBRepository : AbstractDBRepository, IFunzaProductReferenceDBRepository
    {
        public FunzaProductDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<ProductReference>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<DomainModel.Funza.ProductReference>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<DomainModel.Funza.ProductReference>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Funza Products", ex);
            }

            return result;
        }

        

        public OperationResponse<ProductReference> GetById(int id)
        {
            var result = new OperationResponse<ProductReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductReference>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Product {id}", ex);
            }

            return result;
        }

        public OperationResponse<ProductReference> GetByFunzaId(int id)
        {
            var result = new OperationResponse<ProductReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductReference>().Where(o => o.FunzaId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Product {id}", ex);
            }

            return result;
        }


        public OperationResponse<PageResult<FunzaProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<FunzaProductPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<FunzaProductPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<ProductReference>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.ReferenceDescription.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {


                    var query = dbLocator.Set<ProductReference>().AsQueryable();


                    var advancedSorting = new List<SortItem<ProductReference>>();
                    Expression<Func<ProductReference, object>> expression = null;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyCustomerId;
                    //    advancedSorting.Add(new SortItem<ProductReference> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<ProductReference>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<ProductReference, FunzaProductPageQueryCommandOutputDTO>(predicate, input, sorting, o => new FunzaProductPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.ReferenceDescription,
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

        public OperationResponse Add(ProductReference entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Funza Product", ex);
            }

            return result;
            
        }

    }
}
