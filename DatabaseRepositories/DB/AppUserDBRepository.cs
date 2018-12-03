using ApplicationLogic.Business.Commands.AppUser.AuthenticateCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.RegisterCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.UpdateCommand.Models;
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

namespace DatabaseRepositories.DB
{
    public class AppUserDBRepository : AbstractDBRepository, IAppUserDBRepository
    {
        public AppUserDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public IEnumerable<AppUserGetAllCommandOutputDTO> GetAll()
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                return dbLocator.Set<AppUser>().Select(entityItem => new AppUserGetAllCommandOutputDTO
                {
                    Id = entityItem.Id,
                    UserName = entityItem.UserName,
                    Email = entityItem.Email

                }).ToList();
            }
        }

        public PageResult<AppUserPageQueryCommandOutputDTO> PageQuery(PageQuery<AppUserPageQueryCommandInputDTO> input)
        {
            // predicate construction
            var predicate = PredicateBuilderExtension.True<AppUser>();
            if (input.CustomFilter != null)
            {
                var filter = input.CustomFilter;
                if (!string.IsNullOrWhiteSpace(filter.Term))
                {
                    predicate = predicate.And(o => o.UserName.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase) || o.Email.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                }
            }

            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var query = dbLocator.Set<AppUser>().AsQueryable();


                var advancedSorting = new List<SortItem<AppUser>>();
                Expression<Func<AppUser, object>> expression;
                //if (input.Sort.ContainsKey("email"))
                //{
                //    expression = o => o.AppUserThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyAppUserId;
                //    advancedSorting.Add(new SortItem<AppUser> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                //}

                var sorting = new SortingDTO<AppUser>(input.Sort, advancedSorting);

                var result = query.ProcessPagingSort<AppUser, AppUserPageQueryCommandOutputDTO>(predicate, input, sorting, o => new AppUserPageQueryCommandOutputDTO
                {
                    Id = o.Id,
                    UserName = o.UserName,
                    Email = o.Email,
                    FirstName = o.FirstName,
                    LastName = o.LastName
                });

                return result;
            }
        }

        public AppUserGetByIdCommandOutputDTO GetById(string id)
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                return dbLocator.Set<AppUser>().Where(o => o.Id == id).Select(entityItem => new AppUserGetByIdCommandOutputDTO
                {
                    Id = entityItem.Id,
                    Email = entityItem.Email,
                    FirstName = entityItem.FirstName,
                    LastName = entityItem.LastName,
                    PictureUrl = entityItem.PictureUrl,
                    UserName = entityItem.UserName
                }).FirstOrDefault()
                ;
            }
        }

        public OperationResponse<AppUserRegisterCommandOutputDTO> Insert(AppUserRegisterCommandInputDTO input)
        {
            var result = new OperationResponse<AppUserRegisterCommandOutputDTO>();
            try
            {
                var entity = new AppUser
                {
                    Email = input.Email,
                    UserName = input.UserName,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    PictureUrl = input.PictureUrl,
                    PasswordHash = input.PasswordHash,
                    PasswordSalt = input.PasswordSalt,
                };

                using (var dbLocator = AmbientDbContextLocator.Get<IdentityDBContext>())
                {
                    dbLocator.Add(entity);
                    dbLocator.SaveChanges();

                    var dto = dbLocator.Set<AppUser>().Where(o => o.Id == entity.Id).Select(o => new AppUserRegisterCommandOutputDTO
                    {
                        Email = o.Email,
                        FirstName = o.FirstName,
                        LastName = o.LastName,
                        PasswordHash = o.PasswordHash,
                        PasswordSalt = o.PasswordSalt,
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

        public AppUserUpdateCommandOutputDTO Update(AppUserUpdateCommandInputDTO input)
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<AppUser>().FirstOrDefault(o => o.Id == input.Id);
                if (entity != null)
                {
                    entity.FirstName = input.FirstName;
                    entity.LastName = input.LastName;
                    entity.EmailConfirmed = input.EmailConfirmed;
                }

                dbLocator.SaveChanges();


                var result = dbLocator.Set<AppUser>().Where(o => o.Id == entity.Id).Select(o => new AppUserUpdateCommandOutputDTO
                {
                    Id = o.Id,
                    UserName = o.UserName,
                    Email = o.Email
                }).FirstOrDefault();

                return result;
            }
        }

        public AppUserDeleteCommandOutputDTO Delete(string id)
        {
            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<AppUser>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();

                    var result = dbLocator.Set<AppUser>().Where(o => o.Id == entity.Id).Select(o => new AppUserDeleteCommandOutputDTO
                    {
                        Id = o.Id,
                        UserName = o.UserName,
                        CreatedAt = o.CreatedAt
                    }).FirstOrDefault();

                    return result;
                }
            }

            return null;
        }


        public OperationResponse<AppUserAuthenticateCommandOutputDTO> Authenticate(AppUserAuthenticateCommandInputDTO input)
        {
            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var result = new OperationResponse<AppUserAuthenticateCommandOutputDTO>();

                if (string.IsNullOrEmpty(input.UserName) || string.IsNullOrEmpty(input.Password))
                    return result;

                var entity = dbLocator.Set<AppUser>().FirstOrDefault(x => x.UserName == input.UserName || x.Email == input.UserName);

                // check if username exists
                if (entity == null)
                    return result;

                // check if password is correct
                if (!HashHelper.VerifyPasswordHash(input.Password, entity.PasswordHash, entity.PasswordSalt))
                    return result;

                result.Bag = new AppUserAuthenticateCommandOutputDTO
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    PictureUrl = entity.PictureUrl,
                    UserName = entity.UserName
                };
                return result;
            }
        }
    }
}
