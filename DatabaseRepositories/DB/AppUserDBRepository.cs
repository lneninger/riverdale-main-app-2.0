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
using Framework.Core.Messages;
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

        public OperationResponse<IEnumerable<AppUserGetAllCommandOutputDTO>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<AppUserGetAllCommandOutputDTO>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<AppUser>().Select(entityItem => new AppUserGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        UserName = entityItem.UserName,
                        Email = entityItem.Email

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error Geting all user", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<AppUserPageQueryCommandOutputDTO>> PageQuery(PageQuery<AppUserPageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<AppUserPageQueryCommandOutputDTO>>();
            try
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
                    //Expression<Func<AppUser, object>> expression;
                    //if (input.Sort.ContainsKey("email"))
                    //{
                    //    expression = o => o.AppUserThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyAppUserId;
                    //    advancedSorting.Add(new SortItem<AppUser> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<AppUser>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<AppUser, AppUserPageQueryCommandOutputDTO>(predicate, input, sorting, o => new AppUserPageQueryCommandOutputDTO
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
            catch (Exception ex)
            {
                result.AddException($"Error geting users", ex);
            }

            return result;
        }

        public OperationResponse<AppUserGetByIdCommandOutputDTO> GetById(string id)
        {
            var result = new OperationResponse<AppUserGetByIdCommandOutputDTO>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<AppUser>().Where(o => o.Id == id).Select(entityItem => new AppUserGetByIdCommandOutputDTO
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
            catch (Exception ex)
            {
                result.AddException($"Error Geting User {id}", ex);
            }

            return result;
        }

        public OperationResponse<AppUserRegisterCommandOutputDTO> Insert(AppUserRegisterCommandInputDTO input)
        {
            var result = new OperationResponse<AppUserRegisterCommandOutputDTO>();
            try
            {
                var entity = new AppUser
                {
                    Email = input.Email,
                    NormalizedEmail = input.NormalizedEmail,
                    UserName = input.UserName,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    PictureUrl = input.PictureUrl,
                    //PasswordHash = input.PasswordHash,
                    //PasswordSalt = input.PasswordSalt,
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
                        //PasswordHash = o.PasswordHash,
                        //PasswordSalt = o.PasswordSalt,
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

        public OperationResponse<AppUserUpdateCommandOutputDTO> Update(AppUserUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<AppUserUpdateCommandOutputDTO>();
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


                var dbResult = dbLocator.Set<AppUser>().Where(o => o.Id == entity.Id).Select(o => new AppUserUpdateCommandOutputDTO
                {
                    Id = o.Id,
                    UserName = o.UserName,
                    Email = o.Email
                }).FirstOrDefault();

                result.Bag = dbResult;
                return result;
            }
        }

        public OperationResponse<AppUserDeleteCommandOutputDTO> Delete(string id)
        {
            var result = new OperationResponse<AppUserDeleteCommandOutputDTO>();
            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<AppUser>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();

                    var dbResult = dbLocator.Set<AppUser>().Where(o => o.Id == entity.Id).Select(o => new AppUserDeleteCommandOutputDTO
                    {
                        Id = o.Id,
                        UserName = o.UserName,
                        CreatedAt = o.CreatedAt
                    }).FirstOrDefault();

                    result.Bag = dbResult;
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
                //if (!HashHelper.VerifyPasswordHash(input.Password, entity.PasswordHash/*, entity.PasswordSalt*/))
                //    return result;

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


        /***************************Validation************************************/

        public OperationResponse<bool> ExistsByEmail(string email)
        {
            var result = new OperationResponse<bool>();
            try
            {
                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = 0 == dbLocator.Set<AppUser>().Count(o => o.NormalizedEmail.Equals(email));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public OperationResponse<bool> ExistsByUserName(string userName)
        {
            var result = new OperationResponse<bool>();
            try
            {
                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = 0 == dbLocator.Set<AppUser>().Count(o => o.NormalizedUserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
                }

            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public OperationResponse<bool> ExistsByEmailOrUserName(string email, string userName)
        {
            var result = new OperationResponse<bool>();
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
