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
using Framework.Storage.DataHolders.Messages;

namespace DatabaseRepositories.DB
{
    public class ProductColorTypeDBRepository : AbstractDBRepository, IProductColorTypeDBRepository
    {
        public ProductColorTypeDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<ProductColorTypeGetAllCommandOutputDTO>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<ProductColorTypeGetAllCommandOutputDTO>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<ProductColorType>().Select(entityItem => new ProductColorTypeGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Name = entityItem.Name,
                        HexCode = entityItem.HexCode,
                        IsBasicColor = entityItem.IsBasicColor,

                    }).ToList();
                }
            }
            catch (Exception ex)
            {

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
                    Expression<Func<ProductColorType, object>> expression;

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

        public OperationResponse<ProductColorTypeGetByIdCommandOutputDTO> GetById(string id)
        {
            var result = new OperationResponse<ProductColorTypeGetByIdCommandOutputDTO>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<ProductColorType>().Where(o => o.Id == id).Select(entityItem => new ProductColorTypeGetByIdCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Name = entityItem.Name,
                        HexCode = entityItem.HexCode,
                        IsBasicColor = entityItem.IsBasicColor,
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error geting customer freightout {id}", ex);
            }

            return result;
        }

        public OperationResponse<ProductColorTypeInsertCommandOutputDTO> Insert(ProductColorTypeInsertCommandInputDTO input)
        {
            var result = new OperationResponse<ProductColorTypeInsertCommandOutputDTO>();
            try
            {
                var entity = new ProductColorType
                {
                    Id = input.Id,
                    Name = input.Name,
                    HexCode = input.HexCode,
                    IsBasicColor = input.IsBasicColor
                };

                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    dbLocator.Add(entity);
                    dbLocator.SaveChanges();

                    var dbResult = dbLocator.Set<ProductColorType>().Where(o => o.Id == entity.Id).Select(o => new ProductColorTypeInsertCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name
                        //ERPId = o.ERPId
                    }).FirstOrDefault();

                    result.Bag = dbResult;
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding customer freightout", ex);
            }

            return result;
        }

        public OperationResponse<ProductColorTypeUpdateCommandOutputDTO> Update(ProductColorTypeUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<ProductColorTypeUpdateCommandOutputDTO>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    var entity = dbLocator.Set<ProductColorType>().FirstOrDefault(o => o.Id == input.Id);
                    if (entity != null)
                    {
                        entity.Name = input.Name;
                        entity.HexCode = input.HexCode;
                        entity.IsBasicColor = input.IsBasicColor;
                    }

                    dbLocator.SaveChanges();

                    var dbResult = dbLocator.Set<ProductColorType>().Where(o => o.Id == entity.Id).Select(o => new ProductColorTypeUpdateCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name
                        //ERPId = o.ERPId
                    }).FirstOrDefault();

                    result.Bag = dbResult;
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error updating customer freightout", ex);
            }

            return result;
        }

        public OperationResponse<ProductColorTypeDeleteCommandOutputDTO> Delete(string id)
        {
            var result = new OperationResponse<ProductColorTypeDeleteCommandOutputDTO>();
            try
            {
                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    var entity = dbLocator.Set<ProductColorType>().FirstOrDefault(o => o.Id == id);
                    if (entity != null)
                    {
                        entity.DeletedAt = DateTime.UtcNow;
                        dbLocator.SaveChanges();

                        var dbResult = dbLocator.Set<ProductColorType>().Where(o => o.Id == entity.Id).Select(o => new ProductColorTypeDeleteCommandOutputDTO
                        {
                            Id = o.Id,
                            Name = o.Name
                            //ERPId = o.ERPId
                        }).FirstOrDefault();

                        result.Bag = dbResult;
                    }
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error deleting customer freightout", ex);
            }

            return result;
        }


    }
}
