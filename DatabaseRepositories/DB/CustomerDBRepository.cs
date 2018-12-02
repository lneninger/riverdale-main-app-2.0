using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Customer.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.Customer.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.Customer.InsertCommand.Models;
using ApplicationLogic.Business.Commands.Customer.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.Customer.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using DomainModel._Commons.Enums;

namespace DatabaseRepositories.DB
{
    public class CustomerDBRepository : AbstractDBRepository, ICustomerDBRepository
    {
        public CustomerDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public IEnumerable<CustomerGetAllCommandOutputDTO> GetAll()
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                return dbLocator.Set<Customer>().Select(entityItem => new CustomerGetAllCommandOutputDTO
                {
                    Id = entityItem.Id,
                    Name = entityItem.Name,
                    CreatedAt = entityItem.CreatedAt

                }).ToList();
            }
        }

        public PageResult<CustomerPageQueryCommandOutputDTO> PageQuery(PageQuery<CustomerPageQueryCommandInputDTO> input)
        {
            // predicate construction
            var predicate = PredicateBuilderExtension.True<Customer>();
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
                var query = dbLocator.Set<Customer>().AsQueryable();


                var advancedSorting = new List<SortItem<Customer>>();
                Expression<Func<Customer, object>> expression;
                if (input.Sort.ContainsKey("erpId"))
                {
                    expression = o => o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyCustomerId;
                    advancedSorting.Add(new SortItem<Customer> { PropertyName="erpId", SortExpression = expression, SortOrder = "desc"});
                }

                var sorting = new SortingDTO<Customer>(input.Sort, advancedSorting);

                var result = query.ProcessPagingSort<Customer, CustomerPageQueryCommandOutputDTO>(predicate, input, sorting, o => new CustomerPageQueryCommandOutputDTO
                {
                    Id = o.Id,
                    Name = o.Name,
                    ERPId = o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == DomainModel._Commons.Enums.ThirdPartyAppTypeEnum.BusinessERP).Select(thid => thid.ThirdPartyCustomerId).FirstOrDefault(),
                    SalesforceId = o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == DomainModel._Commons.Enums.ThirdPartyAppTypeEnum.Salesforce).Select(thid => thid.ThirdPartyCustomerId).FirstOrDefault(),
                    CreatedAt = o.CreatedAt
                });

                return result;
            }

        }

        public CustomerGetByIdCommandOutputDTO GetById(int id)
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                return dbLocator.Set<Customer>().Where(o => o.Id == id).Select(entityItem => new CustomerGetByIdCommandOutputDTO
                {
                    Id = entityItem.Id,
                    Name = entityItem.Name,
                    ThirdPartySettings = entityItem.CustomerThirdPartyAppSettings.Select(third => new CustomerGetByIdCommandOutputThirdPartySettingsDTO {
                        Id = third.Id,
                        ThirdPartyAppTypeId = third.ThirdPartyAppTypeId,
                        ThirdPartyCustomerId = third.ThirdPartyCustomerId
                    }),
                    Freightout = entityItem.CustomerFreightouts.Select(freightoutItem => new CustomerGetByIdCommandOutputFreightoutDTO {
                        Id = freightoutItem.Id,
                        Cost = freightoutItem.Cost,
                        SecondLeg = freightoutItem.SecondLeg,
                        SurchargeHourly = freightoutItem.SurchargeHourly,
                        SurchargeYearly = freightoutItem.SurchargeYearly,
                        WProtect = freightoutItem.WProtect,
                        DateFrom = freightoutItem.DateFrom,
                        DateTo = freightoutItem.DateTo,

                    }).FirstOrDefault()
                }).FirstOrDefault();
            }
        }

        public CustomerInsertCommandOutputDTO Insert(CustomerInsertCommandInputDTO input)
        {
            var entity = new Customer
            {
                Name = input.Name,
            };

            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                dbLocator.Add(entity);
                dbLocator.SaveChanges();

                var result = dbLocator.Set<Customer>().Where(o => o.Id == entity.Id).Select(o => new CustomerInsertCommandOutputDTO
                {
                    Id = o.Id,
                    Name = o.Name
                }).FirstOrDefault();

                return result;
            }

        }

        public CustomerUpdateCommandOutputDTO Update(CustomerUpdateCommandInputDTO input)
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<Customer>().FirstOrDefault(o => o.Id == input.Id);
                if (entity != null)
                {
                    entity.Name = input.Name;
                }

                dbLocator.SaveChanges();


                var result = dbLocator.Set<Customer>().Where(o => o.Id == entity.Id).Select(o => new CustomerUpdateCommandOutputDTO
                {
                    Id = o.Id,
                    Name = o.Name
                }).FirstOrDefault();

                return result;
            }
        }

        public CustomerDeleteCommandOutputDTO Delete(int id)
        {
            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<Customer>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();

                    var result = dbLocator.Set<Customer>().Where(o => o.Id == entity.Id).Select(o => new CustomerDeleteCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name
                    }).FirstOrDefault();

                    return result;
                }
            }

            return null;
        }

       
    }
}
