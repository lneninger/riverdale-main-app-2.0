using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.InsertCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.CustomerFreightout.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using DomainModel._Commons.Enums;
using Framework.Core.Messages;

namespace DatabaseRepositories.DB
{
    public class CustomerFreightoutDBRepository : AbstractDBRepository, ICustomerFreightoutDBRepository
    {
        public CustomerFreightoutDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<CustomerFreightout>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<CustomerFreightout>>();

            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<CustomerFreightout>().AsEnumerable()/*.Select(entityItem => new CustomerFreightoutGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Cost = entityItem.Cost,
                        CustomerFreightoutRateTypeId = entityItem.CustomerFreightoutRateTypeId,
                        CustomerId = entityItem.CustomerId,
                        DateFrom = entityItem.DateFrom,
                        DateTo = entityItem.DateTo,
                        SecondLeg = entityItem.SecondLeg,
                        SurchargeHourly = entityItem.SurchargeHourly,
                        SurchargeYearly = entityItem.SurchargeYearly,
                        WProtect = entityItem.WProtect,
                    }).ToList()*/;
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all customer freightout", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<CustomerFreightoutPageQueryCommandOutputDTO>> PageQuery(PageQuery<CustomerFreightoutPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<CustomerFreightoutPageQueryCommandOutputDTO>>();

            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<CustomerFreightout>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.Customer.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    var query = dbLocator.Set<CustomerFreightout>().AsQueryable();


                    var advancedSorting = new List<SortItem<CustomerFreightout>>();
                    Expression<Func<CustomerFreightout, object>> expression;
                    if (input.Sort.ContainsKey("customerName"))
                    {
                        expression = o => o.Customer.Name;
                        advancedSorting.Add(new SortItem<CustomerFreightout> { PropertyName = "customerName", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<CustomerFreightout>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<CustomerFreightout, CustomerFreightoutPageQueryCommandOutputDTO>(predicate, input, sorting, o => new CustomerFreightoutPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        CustomerName = o.Customer.Name,
                        Cost = o.Cost,
                        CustomerFreightoutRateTypeId = o.CustomerFreightoutRateTypeId,
                        CustomerId = o.CustomerId,
                        DateFrom = o.DateFrom,
                        DateTo = o.DateTo,
                        SecondLeg = o.SecondLeg,
                        SurchargeHourly = o.SurchargeHourly,
                        SurchargeYearly = o.SurchargeYearly,
                        WProtect = o.WProtect,
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting customer freightout page query", ex);
            }

            return result;
        }

        public OperationResponse<CustomerFreightout> GetById(int id)
        {
            var result = new OperationResponse<CustomerFreightout>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<CustomerFreightout>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting customer freightout {id}", ex);
            }

            return result;
        }

        public OperationResponse<CustomerFreightoutInsertCommandOutputDTO> Insert(CustomerFreightout entity)
        {
            var result = new OperationResponse<CustomerFreightoutInsertCommandOutputDTO>();

            try
            {
                var entity = new CustomerFreightout
                {
                    Cost = input.Cost ?? 0,
                    CustomerFreightoutRateTypeId = input.CustomerFreightoutRateTypeId,
                    CustomerId = input.CustomerId,
                    DateFrom = input.DateFrom ?? DateTime.UtcNow,
                    DateTo = input.DateTo ?? DateTime.UtcNow,
                    SecondLeg = input.SecondLeg ?? 0,
                    SurchargeHourly = input.SurchargeHourly,
                    SurchargeYearly = input.SurchargeYearly,
                    WProtect = input.WProtect ?? 0,
                };

                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    dbLocator.Add(entity);
                    dbLocator.SaveChanges();

                    var dbResult = dbLocator.Set<CustomerFreightout>().Where(o => o.Id == entity.Id).Select(o => new CustomerFreightoutInsertCommandOutputDTO
                    {
                        Id = o.Id,
                        CustomerId = o.CustomerId,
                        CustomerName = o.Customer.Name,
                        Cost = o.Cost,
                        CustomerFreightoutRateTypeId = o.CustomerFreightoutRateTypeId,
                        DateFrom = o.DateFrom,
                        DateTo = o.DateTo,
                        SecondLeg = o.SecondLeg,
                        SurchargeHourly = o.SurchargeHourly,
                        SurchargeYearly = o.SurchargeYearly,
                        WProtect = o.WProtect,
                    }).FirstOrDefault();

                    result.Bag = dbResult;

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding customer freightout {input.ERPId}", ex);
            }

            return result;
        }

        public OperationResponse<CustomerFreightoutUpdateCommandOutputDTO> Update(CustomerFreightoutUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<CustomerFreightoutUpdateCommandOutputDTO>();

            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    var entity = dbLocator.Set<CustomerFreightout>().FirstOrDefault(o => o.Id == input.Id);
                    if (entity != null)
                    {
                        entity.Cost = input.Cost;
                        entity.CustomerFreightoutRateTypeId = input.CustomerFreightoutRateTypeId;
                        entity.CustomerId = input.CustomerId;
                        entity.DateFrom = input.DateFrom;
                        entity.DateTo = input.DateTo;
                        entity.SecondLeg = input.SecondLeg;
                        entity.SurchargeHourly = input.SurchargeHourly;
                        entity.SurchargeYearly = input.SurchargeYearly;
                        entity.WProtect = input.WProtect;
                    }

                    dbLocator.SaveChanges();


                    var dbResult = dbLocator.Set<CustomerFreightout>().Where(o => o.Id == entity.Id).Select(o => new CustomerFreightoutUpdateCommandOutputDTO
                    {
                        Id = o.Id,
                        CustomerId = o.CustomerId,
                        CustomerName = o.Customer.Name,
                        Cost = o.Cost,
                        CustomerFreightoutRateTypeId = o.CustomerFreightoutRateTypeId,
                        DateFrom = o.DateFrom,
                        DateTo = o.DateTo,
                        SecondLeg = o.SecondLeg,
                        SurchargeHourly = o.SurchargeHourly,
                        SurchargeYearly = o.SurchargeYearly,
                        WProtect = o.WProtect,
                    }).FirstOrDefault();
                    result.Bag = dbResult;

                    return result;
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public OperationResponse<CustomerFreightoutDeleteCommandOutputDTO> Delete(int id)
        {
            var result = new OperationResponse<CustomerFreightoutDeleteCommandOutputDTO>();
            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<CustomerFreightout>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();

                    var dbResult = dbLocator.Set<CustomerFreightout>().Where(o => o.Id == entity.Id).Select(o => new CustomerFreightoutDeleteCommandOutputDTO
                    {
                        Id = o.Id,
                        CustomerId = o.CustomerId,
                        CustomerName = o.Customer.Name,
                        Cost = o.Cost,
                        CustomerFreightoutRateTypeId = o.CustomerFreightoutRateTypeId,
                        DateFrom = o.DateFrom,
                        DateTo = o.DateTo,
                        SecondLeg = o.SecondLeg,
                        SurchargeHourly = o.SurchargeHourly,
                        SurchargeYearly = o.SurchargeYearly,
                        WProtect = o.WProtect,
                    }).FirstOrDefault();

                    result.Bag = dbResult;
                    return result;
                }
            }

            return null;
        }


    }
}
