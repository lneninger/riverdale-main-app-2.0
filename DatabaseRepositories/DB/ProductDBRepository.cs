using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Product.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Product.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.Product.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.Product.InsertCommand.Models;
using ApplicationLogic.Business.Commands.Product.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.Product.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using DomainModel._Commons.Enums;
using Framework.Storage.DataHolders.Messages;
using DomainModel.Product;
using ApplicationLogic.Business.Commands.Product.Commons;

namespace DatabaseRepositories.DB
{
    public class ProductDBRepository : AbstractDBRepository, IProductDBRepository
    {
        public ProductDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<ProductGetAllCommandOutputDTO>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<ProductGetAllCommandOutputDTO>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<AbstractProduct>().Select(entityItem => new ProductGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Name = entityItem.Name,
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

        public OperationResponse<PageResult<ProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<ProductPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<AbstractProduct>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {


                    var query = dbLocator.Set<AbstractProduct>().AsQueryable();


                    var advancedSorting = new List<SortItem<AbstractProduct>>();
                    Expression<Func<AbstractProduct, object>> expression;
                    if (input.Sort.ContainsKey("productType"))
                    {
                        expression = o => o.ProductType.Name;
                        advancedSorting.Add(new SortItem<AbstractProduct> { PropertyName = "productType", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<AbstractProduct>(input.Sort, advancedSorting);

                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting customer page query", ex);
            }

            return result;
        }

        public OperationResponse<ProductGetByIdCommandOutputDTO> GetById(int id)
        {
            var result = new OperationResponse<ProductGetByIdCommandOutputDTO>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<AbstractProduct>().Where(o => o.Id == id).Select(entityItem => new ProductGetByIdCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Name = entityItem.Name,
                        ProductTypeId = entityItem.ProductTypeId
                    }).FirstOrDefault();

                    if (result.Bag == null)
                    {
                        result.AddWarning($"No product found for id {id}");
                    }
                    else
                    {
                        if (result.Bag.ProductTypeEnum == ProductTypeEnum.COMP)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error Geting User {id}", ex);
            }

            return result;
        }

        public OperationResponse<ProductInsertCommandOutputDTO> Insert(ProductInsertCommandInputDTO input)
        {
            var result = new OperationResponse<ProductInsertCommandOutputDTO>();
            var entity = new FlowerProduct
            {
                Name = input.Name,
            };

            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                dbLocator.Add(entity);
                dbLocator.SaveChanges();

                var dbResult = dbLocator.Set<AbstractProduct>().Where(o => o.Id == entity.Id).Select(o => new ProductInsertCommandOutputDTO
                {
                    Id = o.Id,
                    Name = o.Name
                }).FirstOrDefault();

                result.Bag = dbResult;
                return result;
            }

        }

        public OperationResponse<ProductUpdateCommandOutputDTO> Update(ProductUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<ProductUpdateCommandOutputDTO>();
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<AbstractProduct>().FirstOrDefault(o => o.Id == input.Id);
                if (entity != null)
                {
                    entity.Name = input.Name;
                }

                dbLocator.SaveChanges();


                var dbResult = dbLocator.Set<AbstractProduct>().Where(o => o.Id == entity.Id).Select(o => new ProductUpdateCommandOutputDTO
                {
                    Id = o.Id,
                    Name = o.Name
                }).FirstOrDefault();

                result.Bag = dbResult;
                return result;
            }
        }

        public OperationResponse<ProductDeleteCommandOutputDTO> Delete(int id)
        {
            var result = new OperationResponse<ProductDeleteCommandOutputDTO>();

            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<AbstractProduct>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();

                    var dbResult = dbLocator.Set<AbstractProduct>().Where(o => o.Id == entity.Id).Select(o => new ProductDeleteCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name
                    }).FirstOrDefault();

                    result.Bag = dbResult;
                    return result;
                }
            }

            return null;
        }


    }
}
