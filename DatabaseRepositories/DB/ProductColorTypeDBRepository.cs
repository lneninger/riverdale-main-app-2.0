using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.InsertCommand.Models;
using ApplicationLogic.Business.Commands.ProductColorType.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using DomainModel._Commons.Enums;
using Framework.Core.Messages;

namespace DatabaseRepositories.DB
{
    public class ProductColorTypeDBRepository : AbstractDBRepository, IProductColorTypeDBRepository
    {
        public ProductColorTypeDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<ProductColorType>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<ProductColorType>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductColorType>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddError("Error GetAll ProductColorType", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<ProductColorTypePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductColorTypePageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<ProductColorTypePageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<ProductColorType>();
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
                    var query = dbLocator.Set<ProductColorType>().AsQueryable();


                    var advancedSorting = new List<SortItem<ProductColorType>>();
                    //var advancedSorting = new List<Expression<Func<ProductColorType, object>>>();
                    //Expression<Func<ProductColorType, object>> expression;

                    var sorting = new SortingDTO<ProductColorType>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<ProductColorType, ProductColorTypePageQueryCommandOutputDTO>(predicate, input, sorting, o => new ProductColorTypePageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name,
                        HexCode = o.HexCode,
                        IsBasicColor = o.IsBasicColor,
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting customer freightout page query", ex);
            }

            return result;
        }

        public OperationResponse<ProductColorType> GetById(string id)
        {
            var result = new OperationResponse<ProductColorType>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductColorType>().Where(o => o.Id == id).FirstOrDefault();//.Select(entityItem => new ProductColorTypeGetByIdCommandOutputDTO
                    //{
                    //    Id = entityItem.Id,
                    //    Name = entityItem.Name,
                    //    HexCode = entityItem.HexCode,
                    //    IsBasicColor = entityItem.IsBasicColor,
                    //}).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error geting customer freightout {id}", ex);
            }

            return result;
        }

        public OperationResponse Insert(ProductColorType entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding customer freightout", ex);
            }

            return result;
        }

        //public OperationResponse Update(ProductColorType input)
        //{
        //    var result = new OperationResponse<ProductColorTypeUpdateCommandOutputDTO>();
        //    try
        //    {
        //        var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
        //        {
        //            var entity = dbLocator.Set<ProductColorType>().FirstOrDefault(o => o.Id == input.Id);
        //            if (entity != null)
        //            {
                        
        //            }

                   
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.AddException($"Error updating customer freightout", ex);
        //    }

        //    return result;
        //}

        public OperationResponse Delete(ProductColorType entity)
        {
            var result = new OperationResponse();

            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                try
                {
                    dbLocator.Set<ProductColorType>().Remove(entity);
                }
                catch (Exception ex)
                {
                    result.AddException("Error deleting Product Color Type", ex);
                }
            }

            return null;

        }

        public OperationResponse<ProductColorTypeDeleteCommandOutputDTO> LogicalDelete(ProductColorType entity)
        {
            var result = new OperationResponse<ProductColorTypeDeleteCommandOutputDTO>();

            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
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
                    result.AddException("Error voiding Product Color Type", ex);
                }
            }

            return null;
        }

    }
}
