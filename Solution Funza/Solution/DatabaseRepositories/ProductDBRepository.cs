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
using FunzaApplicationLogic.Commands.Funza.ProductPageQueryCommand.Models;

namespace DatabaseRepositories.DB
{
    public class FunzaProductDBRepository : AbstractDBRepository, IProductDBRepository
    {
        public FunzaProductDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<Product>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<DomainModel.Product>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<DomainModel.Product>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Funza Products", ex);
            }

            return result;
        }

        

        public OperationResponse<Product> GetById(int id)
        {
            var result = new OperationResponse<Product>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<Product>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Product {id}", ex);
            }

            return result;
        }

        public OperationResponse<Product> GetByFunzaId(int id)
        {
            var result = new OperationResponse<Product>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<Product>().Where(o => o.FunzaId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Product {id}", ex);
            }

            return result;
        }


        public OperationResponse<PageResult<ProductPageQueryCommandOutput>> PageQuery(PageQuery<ProductPageQueryCommandInput> input)
        {
            var result = new OperationResponse<PageResult<ProductPageQueryCommandOutput>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<Product>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.ReferenceDescription.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                var dbLocator = this.AmbientDbContextLocator.Get<FunzaDBContext>();
                {


                    var query = dbLocator.Set<Product>().AsQueryable();


                    var advancedSorting = new List<SortItem<Product>>();
                    Expression<Func<Product, object>> expression = null;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyCustomerId;
                    //    advancedSorting.Add(new SortItem<Product> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<Product>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<Product, ProductPageQueryCommandOutput>(predicate, input, sorting, o => new ProductPageQueryCommandOutput
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

        public OperationResponse Add(Product entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Funza Product", ex);
            }

            return result;
            
        }

        public OperationResponse DeleteNotInIntegration(Guid integrationId)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                var notInIntegrationItems = dbLocator.Set<Product>().Where(item => item.IntegrationId != integrationId && item.IsDeleted != true);
                foreach (var item in notInIntegrationItems) {
                    item.DeletedAt = DateTime.UtcNow;
                }

                dbLocator.SaveChanges();
            }
            catch (Exception ex)
            {
                result.AddException($"Error deleting Funza Product", ex);
            }

            return result;
        }
    }
}
