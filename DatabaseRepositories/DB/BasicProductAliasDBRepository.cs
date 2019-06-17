using ApplicationLogic.Business.Commands.BasicProductAlias.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.BasicProductAlias.PageQueryCommand.Models;
using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
using DomainModel.Product;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
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
    public class BasicProductAliasDBRepository : AbstractDBRepository, IBasicProductAliasDBRepository
    {
        public BasicProductAliasDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<BasicProductAlias>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<BasicProductAlias>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<BasicProductAlias>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Basic Product Alias", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<BasicProductAliasPageQueryCommandOutputDTO>> PageQuery(PageQuery<BasicProductAliasPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<BasicProductAliasPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<BasicProductAlias>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {


                    var query = dbLocator.Set<BasicProductAlias>().AsQueryable();


                    var advancedSorting = new List<SortItem<BasicProductAlias>>();
                    Expression<Func<BasicProductAlias, object>> expression;
                    if (input.Sort.ContainsKey("productName"))
                    {
                        expression = o => o.Product.Name;
                        advancedSorting.Add(new SortItem<BasicProductAlias> { PropertyName = "productName", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<BasicProductAlias>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<BasicProductAlias, BasicProductAliasPageQueryCommandOutputDTO>(predicate, input, sorting, o => new BasicProductAliasPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name,

                        ProductId = o.ProductId,
                        ProductName = o.Product.Name,

                        ProductCategorySizeId = o.ProductCategorySizeId,
                        ProductCategorySize = o.ProductCategorySize.Size,

                        ColorTypeId = o.ColorTypeId,
                        ColorTypeName = o.ColorType.Name,
                        CreatedAt = o.CreatedAt
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Basic Product Alias page query", ex);
            }

            return result;
        }

        public OperationResponse<BasicProductAlias> GetById(int id)
        {
            var result = new OperationResponse<BasicProductAlias>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                result.Bag = dbLocator.Set<BasicProductAlias>().Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Basic Product Alias {id}", ex);
            }

            return result;
        }

        public OperationResponse Insert(BasicProductAlias entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Basic Product Alias", ex);
            }

            return result;

        }


        public OperationResponse<BasicProductAliasDeleteCommandOutputDTO> Delete(BasicProductAlias entity)
        {
            var result = new OperationResponse<BasicProductAliasDeleteCommandOutputDTO>();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                dbLocator.Set<BasicProductAlias>().Remove(entity);
            }
            catch (Exception ex)
            {
                result.AddException("Error deleting Basic Product Alias", ex);
            }

            return null;
        }

        public OperationResponse<BasicProductAliasDeleteCommandOutputDTO> LogicalDelete(BasicProductAlias entity)
        {
            var result = new OperationResponse<BasicProductAliasDeleteCommandOutputDTO>();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            try
            {
                if (!(entity.IsDeleted ?? false))
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.AddException("Error voiding Basic Product Alias", ex);
            }

            return null;
        }


    }
}
