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

namespace DatabaseRepositories.DB
{
    public class CustomerFreightoutDBRepository : AbstractDBRepository, ICustomerFreightoutDBRepository
    {
        public CustomerFreightoutDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public IEnumerable<CustomerFreightoutGetAllCommandOutputDTO> GetAll()
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                return dbLocator.Set<CustomerFreightout>().Select(entityItem => new CustomerFreightoutGetAllCommandOutputDTO
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

                }).ToList();
            }
        }

        public PageResult<CustomerFreightoutPageQueryCommandOutputDTO> PageQuery(PageQuery<CustomerFreightoutPageQueryCommandInputDTO> input)
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

                var result = query.ProcessPagingSort<CustomerFreightout, CustomerFreightoutPageQueryCommandOutputDTO>(predicate, input, sorting, o => new CustomerFreightoutPageQueryCommandOutputDTO
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

                return result;
            }

        }

        public CustomerFreightoutGetByIdCommandOutputDTO GetById(int id)
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                return dbLocator.Set<CustomerFreightout>().Where(o => o.Id == id).Select(entityItem => new CustomerFreightoutGetByIdCommandOutputDTO
                {
                    Id = entityItem.Id,
                    CustomerId = entityItem.CustomerId,
                    Cost = entityItem.Cost,
                    CustomerFreightoutRateTypeId = entityItem.CustomerFreightoutRateTypeId,
                    DateFrom = entityItem.DateFrom,
                    DateTo = entityItem.DateTo,
                    SecondLeg = entityItem.SecondLeg,
                    SurchargeHourly = entityItem.SurchargeHourly,
                    SurchargeYearly = entityItem.SurchargeYearly,
                    WProtect = entityItem.WProtect,

                }).FirstOrDefault();
            }
        }

        public CustomerFreightoutInsertCommandOutputDTO Insert(CustomerFreightoutInsertCommandInputDTO input)
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

            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                dbLocator.Add(entity);
                dbLocator.SaveChanges();

                var result = dbLocator.Set<CustomerFreightout>().Where(o => o.Id == entity.Id).Select(o => new CustomerFreightoutInsertCommandOutputDTO
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

                return result;
            }

        }

        public CustomerFreightoutUpdateCommandOutputDTO Update(CustomerFreightoutUpdateCommandInputDTO input)
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
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


                var result = dbLocator.Set<CustomerFreightout>().Where(o => o.Id == entity.Id).Select(o => new CustomerFreightoutUpdateCommandOutputDTO
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

                return result;
            }
        }

        public CustomerFreightoutDeleteCommandOutputDTO Delete(int id)
        {
            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<CustomerFreightout>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();

                    var result = dbLocator.Set<CustomerFreightout>().Where(o => o.Id == entity.Id).Select(o => new CustomerFreightoutDeleteCommandOutputDTO
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

                    return result;
                }
            }

            return null;
        }


    }
}
