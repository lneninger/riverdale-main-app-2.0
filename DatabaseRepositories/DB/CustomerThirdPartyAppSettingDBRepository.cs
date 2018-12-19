using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.InsertCommand.Models;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using DomainModel._Commons.Enums;
using Framework.Core.Messages;

namespace DatabaseRepositories.DB
{
    public class CustomerThirdPartyAppSettingDBRepositoryDBRepository : AbstractDBRepository, ICustomerThirdPartyAppSettingDBRepository
    {
        public CustomerThirdPartyAppSettingDBRepositoryDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<CustomerThirdPartyAppSetting>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<CustomerThirdPartyAppSetting>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<CustomerThirdPartyAppSetting>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all customer third party setting", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<CustomerThirdPartyAppSettingPageQueryCommandOutputDTO>> PageQuery(PageQuery<CustomerThirdPartyAppSettingPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<CustomerThirdPartyAppSettingPageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<CustomerThirdPartyAppSetting>();
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
                    var query = dbLocator.Set<CustomerThirdPartyAppSetting>().AsQueryable();


                    var advancedSorting = new List<SortItem<CustomerThirdPartyAppSetting>>();
                    //var advancedSorting = new List<Expression<Func<CustomerThirdPartyAppSetting, object>>>();
                    Expression<Func<CustomerThirdPartyAppSetting, object>> expression;
                    if (input.Sort.ContainsKey("customerName"))
                    {
                        expression = o => o.Customer.Name;
                        advancedSorting.Add(new SortItem<CustomerThirdPartyAppSetting> { PropertyName = "customerName", SortExpression = expression, SortOrder = "desc" });
                    }

                    var sorting = new SortingDTO<CustomerThirdPartyAppSetting>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<CustomerThirdPartyAppSetting, CustomerThirdPartyAppSettingPageQueryCommandOutputDTO>(predicate, input, sorting, o => new CustomerThirdPartyAppSettingPageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        CustomerName = o.Customer.Name,
                        CustomerId = o.CustomerId,
                        ThirdPartyAppTypeId = o.ThirdPartyAppTypeId,
                        ThirdPartyCustomerId = o.ThirdPartyCustomerId,
                        CreatedAt = o.CreatedAt
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting customer third party setting page query", ex);
            }

            return result;
        }

        public OperationResponse<CustomerThirdPartyAppSetting> GetById(int id)
        {
            var result = new OperationResponse<CustomerThirdPartyAppSetting>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<CustomerThirdPartyAppSetting>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all customer third party setting", ex);
            }

            return result;
        }

        public OperationResponse<CustomerThirdPartyAppSettingInsertCommandOutputDTO> Insert(CustomerThirdPartyAppSettingInsertCommandInputDTO input)
        {
            var result = new OperationResponse<CustomerThirdPartyAppSettingInsertCommandOutputDTO>();
            var entity = new CustomerThirdPartyAppSetting
            {
                CustomerId = input.CustomerId,
                ThirdPartyAppTypeId = input.ThirdPartyAppTypeId,
                ThirdPartyCustomerId = input.ThirdPartyCustomerId,
            };

            var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
            {
                dbLocator.Add(entity);
                dbLocator.SaveChanges();

                var dbResult = dbLocator.Set<CustomerThirdPartyAppSetting>().Where(o => o.Id == entity.Id).Select(o => new CustomerThirdPartyAppSettingInsertCommandOutputDTO
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    CustomerName = o.Customer.Name,
                    ThirdPartyAppTypeId = o.ThirdPartyAppTypeId,
                    ThirdPartyCustomerId = o.ThirdPartyCustomerId,
                }).FirstOrDefault();

                result.Bag = dbResult;

                return result;
            }

        }

        //public OperationResponse<CustomerThirdPartyAppSettingUpdateCommandOutputDTO> Update(CustomerThirdPartyAppSettingUpdateCommandInputDTO input)
        //{
        //    var result = new OperationResponse<CustomerThirdPartyAppSettingUpdateCommandOutputDTO>();
        //    var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
        //    {
        //        var entity = dbLocator.Set<CustomerThirdPartyAppSetting>().FirstOrDefault(o => o.Id == input.Id);
        //        if (entity != null)
        //        {
        //            entity.CustomerId = input.CustomerId;
        //            entity.ThirdPartyAppTypeId = input.ThirdPartyAppTypeId;
        //            entity.ThirdPartyCustomerId = input.ThirdPartyCustomerId;
        //        }

        //        dbLocator.SaveChanges();


        //        var dbResult = dbLocator.Set<CustomerThirdPartyAppSetting>().Where(o => o.Id == entity.Id).Select(o => new CustomerThirdPartyAppSettingUpdateCommandOutputDTO
        //        {
        //            Id = o.Id,
        //            CustomerId = o.CustomerId,
        //            CustomerName = o.Customer.Name,
        //            ThirdPartyAppTypeId = o.ThirdPartyAppTypeId,
        //            ThirdPartyCustomerId = o.ThirdPartyCustomerId,
        //        }).FirstOrDefault();

        //        result.Bag = dbResult;
        //        return result;
        //    }
        //}

        public OperationResponse<CustomerThirdPartyAppSettingDeleteCommandOutputDTO> Delete(int id)
        {
            var result = new OperationResponse<CustomerThirdPartyAppSettingDeleteCommandOutputDTO>();
            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<CustomerThirdPartyAppSetting>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();

                    var dbResult = dbLocator.Set<CustomerThirdPartyAppSetting>().Where(o => o.Id == entity.Id).Select(o => new CustomerThirdPartyAppSettingDeleteCommandOutputDTO
                    {
                        Id = o.Id,
                        CustomerId = o.CustomerId,
                        CustomerName = o.Customer.Name,
                        ThirdPartyAppTypeId = o.ThirdPartyAppTypeId,
                        ThirdPartyCustomerId = o.ThirdPartyCustomerId,
                    }).FirstOrDefault();

                    result.Bag = dbResult;
                    return result;
                }
            }

            return null;
        }


    }
}
