using ApplicationLogic.Business.Commands.AppUser.GetByIdCommand.Models;
using ApplicationLogic.Repositories.DB;
using Framework.Autofac;
using Framework.EF.DbContextImpl;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.SignalR
{
    public class BaseSignalR : Framework.SignalR.BaseHub
    {
        public BaseSignalR(ICurrentUserService currentUserService)
        {
            this.CurrentUserService = currentUserService;
        }

        public ICurrentUserService CurrentUserService { get; }

        protected override string GetUserName()
        {
            var currentUser = this.GetCurrentUser();
            if (currentUser != null && currentUser.IsSucceed)
            {
                return currentUser.Bag.Id;
            }

            return null;
        }

        protected OperationResponse<AppUserGetByIdCommandOutputDTO> GetCurrentUser()
        {
            using (var scope = IoCGlobal.NewScope())
            {
                var userRepository = IoCGlobal.Resolve<IAppUserDBRepository>(null, scope);
                return userRepository.GetById(this.CurrentUserService.CurrentUserId);
            }
        }
    }
}
