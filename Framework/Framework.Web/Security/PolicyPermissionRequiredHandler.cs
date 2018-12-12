using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Web.Security
{
    public class PolicyPermissionRequiredHandler : AuthorizationHandler<PolicyPermissionRequired>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PolicyPermissionRequired requirement)
        {
            if (!context.User.HasClaim(c => c.Type == JwtConstants.Strings.JwtClaimIdentifiers.Permissions))
            {
                //TODO: Use the following if targeting a version of
                //.NET Framework older than 4.6:
                //      return Task.FromResult(0);
                return Task.CompletedTask;
            }

            var permissions = context.User.FindAll(JwtConstants.Strings.JwtClaimIdentifiers.Permissions);//  FindFirst(c => c.Type == ClaimTypes.DateOfBirth && c.Issuer == "http://contoso.com").Value);

            var matchClaimCount = permissions.Count(permission => permission.Value == requirement.Permission);

            if (matchClaimCount > 0)
            {
                context.Succeed(requirement);
            }

            //TODO: Use the following if targeting a version of
            //.NET Framework older than 4.6:
            //      return Task.FromResult(0);
            return Task.CompletedTask;
        }
    }
}
