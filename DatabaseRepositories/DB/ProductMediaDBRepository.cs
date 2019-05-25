using ApplicationLogic.Business.Commands.ProductMedia.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.ProductMedia.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.ProductMedia.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models;
using ApplicationLogic.Business.Commands.ProductMedia.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.ProductMedia.UpdateCommand.Models;
using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
using DomainModel._Commons.Enums;
using DomainModel.Product;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using LMB.PredicateBuilderExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DatabaseRepositories.DB
{
    public class ProductMediaDBRepository : AbstractDBRepository, IProductMediaDBRepository
    {
        public ProductMediaDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<ProductMediaGetAllCommandOutputDTO>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<ProductMediaGetAllCommandOutputDTO>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductMedia>().Select(entityItem => new ProductMediaGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<ProductMediaPageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductMediaPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<ProductMediaPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<ProductMedia>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    //if (!string.IsNullOrWhiteSpace(filter.Term))
                    //{
                    //    predicate = predicate.And(o => o.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    //}
                }

                var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {


                    var query = dbLocator.Set<ProductMedia>().AsQueryable();


                    var advancedSorting = new List<SortItem<ProductMedia>>();
                    //Expression<Func<ProductMedia, object>> expression;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.ProductMediaThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyProductMediaId;
                    //    advancedSorting.Add(new SortItem<ProductMedia> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<ProductMedia>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<ProductMedia, ProductMediaPageQueryCommandOutputDTO>(predicate, input, sorting, o => new ProductMediaPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
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

        public OperationResponse<ProductMedia> GetById(int id)
        {
            var result = new OperationResponse<ProductMedia>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductMedia>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error Geting User {id}", ex);
            }

            return result;
        }

        public OperationResponse Insert(ProductMedia input)
        {
            var result = new OperationResponse<ProductMediaInsertCommandOutputDTO>();

            var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
            dbLocator.Add(input);

            return result;

        }

        public OperationResponse<ProductMediaUpdateCommandOutputDTO> Update(ProductMediaUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<ProductMediaUpdateCommandOutputDTO>();
            var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
            {
                var entity = dbLocator.Set<ProductMedia>().FirstOrDefault(o => o.Id == input.Id);
                if (entity != null)
                {
                }

                dbLocator.SaveChanges();


                var dbResult = dbLocator.Set<ProductMedia>().Where(o => o.Id == entity.Id).Select(o => new ProductMediaUpdateCommandOutputDTO
                {
                    Id = o.Id,
                }).FirstOrDefault();

                result.Bag = dbResult;
                return result;
            }
        }

        public OperationResponse<ProductMediaDeleteCommandOutputDTO> Delete(int id)
        {
            var result = new OperationResponse<ProductMediaDeleteCommandOutputDTO>();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            {
                var entity = dbLocator.Set<ProductMedia>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();

                    var dbResult = dbLocator.Set<ProductMedia>().Where(o => o.Id == entity.Id).Select(o => new ProductMediaDeleteCommandOutputDTO
                    {
                        Id = o.Id,
                    }).FirstOrDefault();

                    result.Bag = dbResult;
                    return result;
                }
            }

            return null;
        }


    }
}
