using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.Funza.CategoryPageQueryCommand.Models;
using LMB.PredicateBuilderExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DatabaseRepositories.DB
{
    public class CategoryDBRepository : AbstractDBRepository, ICategoryDBRepository
    {
        public CategoryDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<Category>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<Category>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<Category>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Funza Categories", ex);
            }

            return result;
        }

        

        public OperationResponse<Category> GetById(int id)
        {
            var result = new OperationResponse<Category>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<Category>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Category {id}", ex);
            }

            return result;
        }

        public OperationResponse<Category> GetByFunzaId(int id)
        {
            var result = new OperationResponse<Category>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                {
                    result.Bag = dbLocator.Set<Category>().Where(o => o.FunzaId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Category {id}", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<CategoryPageQueryCommandOutput>> PageQuery(PageQuery<CategoryPageQueryCommandInput> input)
        {
            var result = new OperationResponse<PageResult<CategoryPageQueryCommandOutput>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<Category>();
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


                    var query = dbLocator.Set<Category>().AsQueryable();


                    var advancedSorting = new List<SortItem<Category>>();
                    Expression<Func<Category, object>> expression = null;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyCustomerId;
                    //    advancedSorting.Add(new SortItem<Color> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<Category>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<Category, CategoryPageQueryCommandOutput>(predicate, input, sorting, o => new CategoryPageQueryCommandOutput
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


        public OperationResponse Add(Category entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Funza Category", ex);
            }

            return result;
            
        }

        public OperationResponse DeleteNotInIntegration(Guid integrationId)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<FunzaDBContext>();
                var notInIntegrationItems = dbLocator.Set<Category>().Where(item => item.IntegrationId != integrationId && item.IsDeleted != true);
                foreach (var item in notInIntegrationItems)
                {
                    item.DeletedAt = DateTime.UtcNow;
                }

                dbLocator.SaveChanges();
            }
            catch (Exception ex)
            {
                result.AddException($"Error deleting Funza Category", ex);
            }

            return result;
        }

    }
}
