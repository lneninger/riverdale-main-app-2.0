﻿using ApplicationLogic.Business.Commands.AppUserRole.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.InsertCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.UpdateCommand.Models;
using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
using DomainModel.Identity;
using EntityFrameworkCore.DbContextScope;
using Framework.Core.Crypto;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Storage.DataHolders.Messages;
using LMB.PredicateBuilderExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ApplicationLogic.Business.Commands.AppUserRole.GetByNameCommand.Models;

namespace DatabaseRepositories.DB
{
    public class AppUserRoleDBRepository : AbstractDBRepository, IAppUserRoleDBRepository
    {
        public AppUserRoleDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<AppUserRoleGetAllCommandOutputDTO>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<AppUserRoleGetAllCommandOutputDTO>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<IdentityDBContext>())
                {
                    result.Bag = dbLocator.Set<IdentityRole>().Select(entityItem => new AppUserRoleGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Name = entityItem.Name,
                        NormalizedName = entityItem.NormalizedName,

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error geting all", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<AppUserRolePageQueryCommandOutputDTO>> PageQuery(PageQuery<AppUserRolePageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<AppUserRolePageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<IdentityRole>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    if (!string.IsNullOrWhiteSpace(filter.Term))
                    {
                        predicate = predicate.And(o => o.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase) || o.NormalizedName.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                using (var dbLocator = this.AmbientDbContextLocator.Get<IdentityDBContext>())
                {
                    var query = dbLocator.Set<IdentityRole>().AsQueryable();


                    var advancedSorting = new List<SortItem<IdentityRole>>();
                    Expression<Func<IdentityRole, object>> expression;
                    //if (input.Sort.ContainsKey("email"))
                    //{
                    //    expression = o => o.AppUserRoleThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyAppUserRoleId;
                    //    advancedSorting.Add(new SortItem<AppUserRole> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<IdentityRole>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<IdentityRole, AppUserRolePageQueryCommandOutputDTO>(predicate, input, sorting, o => new AppUserRolePageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name,
                        NormalizedName = o.NormalizedName,
                    });

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting page query", ex);
            }

            return result;
        }

        public OperationResponse<AppUserRoleGetByIdCommandOutputDTO> GetById(string id)
        {
            var result = new OperationResponse<AppUserRoleGetByIdCommandOutputDTO>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag =  dbLocator.Set<IdentityRole>().Where(o => o.Id == id).Select(entityItem => new AppUserRoleGetByIdCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Name = entityItem.Name,
                        NormalizedName = entityItem.NormalizedName,
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error Geting User {id}", ex);
            }

            return result;
        }

        public OperationResponse<AppUserRoleInsertCommandOutputDTO> Insert(AppUserRoleInsertCommandInputDTO input)
        {
            var result = new OperationResponse<AppUserRoleInsertCommandOutputDTO>();
            try
            {
                var entity = new IdentityRole
                {
                    Id = input.Id,
                    Name = input.Name,
                    NormalizedName = input.NormalizedName,
                };

                using (var dbLocator = AmbientDbContextLocator.Get<IdentityDBContext>())
                {
                    dbLocator.Add(entity);
                    dbLocator.SaveChanges();

                    var dto = dbLocator.Set<IdentityRole>().Where(o => o.Id == entity.Id).Select(o => new AppUserRoleInsertCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name,
                        NormalizedName = o.NormalizedName,
                    }).FirstOrDefault();

                    result.Bag = dto;
                }
            }
            catch (Exception ex)
            {
                result.AddException(null, ex);
            }

            return result;
        }

        public OperationResponse<AppUserRoleUpdateCommandOutputDTO> Update(AppUserRoleUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<AppUserRoleUpdateCommandOutputDTO>();
            using (var dbLocator = AmbientDbContextLocator.Get<IdentityDBContext>())
            {
                var entity = dbLocator.Set<IdentityRole>().FirstOrDefault(o => o.Id == input.Id);
                if (entity != null)
                {
                    entity.Id = input.Id;
                    entity.Name = input.Name;
                    entity.NormalizedName = input.NormalizedName;
                }

                dbLocator.SaveChanges();


                var dbResult = dbLocator.Set<IdentityRole>().Where(o => o.Id == entity.Id).Select(o => new AppUserRoleUpdateCommandOutputDTO
                {
                    Id = o.Id,
                    Name = o.Name,
                    NormalizedName = o.NormalizedName,
                }).FirstOrDefault();

                result.Bag = dbResult;
                return result;
            }
        }

        public OperationResponse<AppUserRoleDeleteCommandOutputDTO> Delete(string id)
        {
            var result = new OperationResponse<AppUserRoleDeleteCommandOutputDTO>();
            using (var dbLocator = this.AmbientDbContextLocator.Get<IdentityDBContext>())
            {
                var entity = dbLocator.Set<IdentityRole>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    dbLocator.Entry(entity).State = EntityState.Deleted;
                    dbLocator.SaveChanges();

                    var dbResult = dbLocator.Set<IdentityRole>().Where(o => o.Id == entity.Id).Select(o => new AppUserRoleDeleteCommandOutputDTO
                    {
                        Id = o.Id,
                        Name = o.Name,
                        NormalizedName = o.NormalizedName,
                    }).FirstOrDefault();

                    result.Bag = dbResult;
                    return result;
                }
            }

            return null;
        }

        public OperationResponse<AppUserRoleGetByNameCommandOutputDTO> GetByName(string name)
        {
                var result = new OperationResponse<AppUserRoleGetByNameCommandOutputDTO>();
                try
                {
                    using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                    {
                        result.Bag = dbLocator.Set<IdentityRole>().Where(o => o.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Select(entityItem => new AppUserRoleGetByNameCommandOutputDTO
                        {
                            Id = entityItem.Id,
                            Name = entityItem.Name,
                            NormalizedName = entityItem.NormalizedName,
                        }).FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    result.AddException($"Error Geting User {name}", ex);
                }

                return result;
        }
    }
}
