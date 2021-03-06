﻿using ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Customer.PageQueryCommand.Models;
using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
using DomainModel._Commons.Enums;
using DomainModel.Company.Customer;
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
    public class CustomerDBRepository : AbstractDBRepository, ICustomerDBRepository
    {
        public CustomerDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<Customer>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<Customer>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<Customer>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Customer", ex);
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

                var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
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

        public OperationResponse<Customer> GetById(int id)
        {
            var result = new OperationResponse<Customer>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<Customer>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Customer {id}", ex);
            }

            return result;
        }

        public OperationResponse Insert(Customer entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Customer", ex);
            }

            return result;
            
        }

        //public OperationResponse<CustomerUpdateCommandOutputDTO> Update(CustomerUpdateCommandInputDTO input)
        //{
        //    var result = new OperationResponse<CustomerUpdateCommandOutputDTO>();
        //    var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
        //    {
        //        var entity = dbLocator.Set<Customer>().FirstOrDefault(o => o.Id == input.Id);
        //        if (entity != null)
        //        {
        //            entity.Name = input.Name;
        //        }

        //        dbLocator.SaveChanges();


        //        var dbResult = dbLocator.Set<Customer>().Where(o => o.Id == entity.Id).Select(o => new CustomerUpdateCommandOutputDTO
        //        {
        //            Id = o.Id,
        //            Name = o.Name
        //        }).FirstOrDefault();

        //        result.Bag = dbResult;
        //        return result;
        //    }
        //}

        public OperationResponse<CustomerDeleteCommandOutputDTO> Delete(Customer entity)
        {
            var result = new OperationResponse<CustomerDeleteCommandOutputDTO>();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
            {
                try
                {
                    dbLocator.Set<Customer>().Remove(entity);
                }
                catch (Exception ex)
                {
                    result.AddException("Error deleting Customer", ex);
                }
            }

            return null;
        }

        public OperationResponse<CustomerDeleteCommandOutputDTO> LogicalDelete(Customer entity)
        {
            var result = new OperationResponse<CustomerDeleteCommandOutputDTO>();

            var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>();
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
                    result.AddException("Error voiding Customer", ex);
                }
            }

            return null;
        }


    }
}
