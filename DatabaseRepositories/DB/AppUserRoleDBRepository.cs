using ApplicationLogic.Business.Commands.AppUserRole.DeleteCommand.Models;
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

namespace DatabaseRepositories.DB
{
    public class AppUserRoleDBRepository : AbstractDBRepository, IAppUserRoleDBRepository
    {
        public AppUserRoleDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public IEnumerable<AppUserRoleGetAllCommandOutputDTO> GetAll()
        {
            using (var dbLocator = AmbientDbContextLocator.Get<IdentityDBContext>())
            {
                return dbLocator.Set<IdentityRole>().Select(entityItem => new AppUserRoleGetAllCommandOutputDTO
                {
                    Id = entityItem.Id,
                    Name = entityItem.Name,
                    NormalizedName = entityItem.NormalizedName,

                }).ToList();
            }
        }

        public PageResult<AppUserRolePageQueryCommandOutputDTO> PageQuery(PageQuery<AppUserRolePageQueryCommandInputDTO> input)
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

                var result = query.ProcessPagingSort<IdentityRole, AppUserRolePageQueryCommandOutputDTO>(predicate, input, sorting, o => new AppUserRolePageQueryCommandOutputDTO
                {
                    Id = o.Id,
                    Name = o.Name,
                    NormalizedName = o.NormalizedName,
                });

                return result;
            }
        }

        public AppUserRoleGetByIdCommandOutputDTO GetById(string id)
        {
            using (var dbLocator = AmbientDbContextLocator.Get<IdentityDBContext>())
            {
                return dbLocator.Set<IdentityRole>().Where(o => o.Id == id).Select(entityItem => new AppUserRoleGetByIdCommandOutputDTO
                {
                    Id = entityItem.Id,
                    Name = entityItem.Name,
                    NormalizedName = entityItem.NormalizedName,
                }).FirstOrDefault()
                ;
            }
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

        public AppUserRoleUpdateCommandOutputDTO Update(AppUserRoleUpdateCommandInputDTO input)
        {
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


                var result = dbLocator.Set<IdentityRole>().Where(o => o.Id == entity.Id).Select(o => new AppUserRoleUpdateCommandOutputDTO
                {
                    Id = o.Id,
                    Name = o.Name,
                    NormalizedName = o.NormalizedName,
                }).FirstOrDefault();

                return result;
            }
        }

        public AppUserRoleDeleteCommandOutputDTO Delete(string id)
        {
            using (var dbLocator = this.AmbientDbContextLocator.Get<IdentityDBContext>())
            {
                var entity = dbLocator.Set<IdentityRole>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    dbLocator.Entry(entity).State = EntityState.Deleted;
                    dbLocator.SaveChanges();

                    var result = dbLocator.Set<IdentityRole>().Where(o => o.Id == entity.Id).Select(o => new AppUserRoleDeleteCommandOutputDTO
                    {
                        Id = o.Id,
                    Name = o.Name,
                    NormalizedName = o.NormalizedName,
                    }).FirstOrDefault();

                    return result;
                }
            }

            return null;
        }


    }
}
