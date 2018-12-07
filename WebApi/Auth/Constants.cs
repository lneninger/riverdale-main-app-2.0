using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverdaleMainApp2_0.Auth
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id", Permissions = "per";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
                public const string Administrator = "administrator";
            }
        }
    }
}
