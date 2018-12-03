using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.AppUser.RegisterCommand.Models;
using Framework.Core.Crypto;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Business.Commands.AppUser.RegisterCommand
{
    public class AppUserRegisterCommand : AbstractDBCommand<DomainModel.Identity.AppUser, IAppUserDBRepository>, IAppUserRegisterCommand
    {
        public AppUserRegisterCommand(IDbContextScopeFactory dbContextScopeFactory, IAppUserDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<AppUserRegisterCommandOutputDTO> Execute(AppUserRegisterCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var internalInput = input.Clone() as AppUserRegisterCommandInputDTO;
                byte[] passwordHash, passwordSalt;
                HashHelper.CreatePasswordHash(internalInput.Password, out passwordHash, out passwordSalt);

                internalInput.PasswordHash = passwordHash;
                internalInput.PasswordSalt = passwordSalt;

                return this.Repository.Insert(internalInput);
            }
        }
    }
}
