using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverdaleMainApp2_0.Auth
{
    public class PermissionPolicies
    {
        public static Dictionary<string, Action<AuthorizationPolicyBuilder>> Policies { get; } = new Dictionary<string, Action<AuthorizationPolicyBuilder>>();

        static PermissionPolicies() {
            var permissionNames = Enum.GetNames(typeof(PermissionsEnum));

            foreach (var permissionName in permissionNames)
            {
                Policies.Add(permissionName, policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Permissions, PermissionsEnum.Customer_Read));
            }
        }
    }
}
