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
using Framework.Core.Messages;

namespace DatabaseRepositories.DB
{
    public class CustomerDBRepository : AbstractDBRepository, ICustomerDBRepository
    {
        public CustomerDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<CustomerGetAllCommandOutputDTO>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<CustomerGetAllCommandOutputDTO>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<Customer>().Select(entityItem => new CustomerGetAllCommandOutputDTO
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

        public OperationResponse<PageResult<CustomerPageQueryCommandOutputDTO>> PageQuery(PageQuery<CustomerPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<CustomerPageQueryCommandOutputDTO>>();
            try
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
                        advancedSorting.Add(new SortItem<Customer> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<Customer>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<Customer, CustomerPageQueryCommandOutputDTO>(predicate, input, sorting, o => new CustomerPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name,
                        ERPId = o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == DomainModel._Commons.Enums.ThirdPartyAppTypeEnum.BusinessERP).Select(thid => thid.ThirdPartyCustomerId).FirstOrDefault(),
                        SalesforceId = o.CustomerThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == DomainModel._Commons.Enums.ThirdPartyAppTypeEnum.Salesforce).Select(thid => thid.ThirdPartyCustomerId).FirstOrDefault(),
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

        public OperationResponse<CustomerGetByIdCommandOutputDTO> GetById(int id)
        {
            var result = new OperationResponse<CustomerGetByIdCommandOutputDTO>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<Customer>().Where(o => o.Id == id).Select(entityItem => new CustomerGetByIdCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Name = entityItem.Name,
                        ThirdPartySettings = entityItem.CustomerThirdPartyAppSettings.Select(third => new CustomerGetByIdCommandOutputThirdPartySettingsDTO
                        {
                            Id = third.Id,
                            ThirdPartyAppTypeId = third.ThirdPartyAppTypeId,
                            ThirdPartyCustomerId = third.ThirdPartyCustomerId
                        }),
                        Freightout = entityItem.CustomerFreightouts.Select(freightoutItem => new CustomerGetByIdCommandOutputFreightoutDTO
                        {
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
            catch (Exception ex)
            {
                result.AddException($"Error Geting User {id}", ex);
            }

            return result;
        }

        public OperationResponse<CustomerInsertCommandOutputDTO> Insert(CustomerInsertCommandInputDTO input)
        {
            var result = new OperationResponse<CustomerInsertCommandOutputDTO>();
            var entity = new Customer
            {
                Name = input.Name,
            };

            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                dbLocator.Add(entity);
                dbLocator.SaveChanges();

                var dbResult = dbLocator.Set<Customer>().Where(o => o.Id == entity.Id).Select(o => new CustomerInsertCommandOutputDTO
                {
                    Id = o.Id,
                    Name = o.Name
                }).FirstOrDefault();

                result.Bag = dbResult;
                return result;
            }

        }

        public OperationResponse<CustomerUpdateCommandOutputDTO> Update(CustomerUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<CustomerUpdateCommandOutputDTO>();
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<Customer>().FirstOrDefault(o => o.Id == input.Id);
                if (entity != null)
                {
                    entity.Name = input.Name;
                }

                dbLocator.SaveChanges();


                var dbResult = dbLocator.Set<Customer>().Where(o => o.Id == entity.Id).Select(o => new CustomerUpdateCommandOutputDTO
                {
                    Id = o.Id,
                    Name = o.Name
                }).FirstOrDefault();

                result.Bag = dbResult;
                return result;
            }
        }

        public OperationResponse<CustomerDeleteCommandOutputDTO> Delete(int id)
        {
            var result = new OperationResponse<CustomerDeleteCommandOutputDTO>();

            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<Customer>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();

                    var dbResult = dbLocator.Set<Customer>().Where(o => o.Id == entity.Id).Select(o => new CustomerDeleteCommandOutputDTO
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
