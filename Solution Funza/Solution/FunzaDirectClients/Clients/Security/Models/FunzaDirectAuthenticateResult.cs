using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.Quote.Models
{
    public class FunzaDirectAuthenticateResulWrapper{
        public FunzaDirectAuthenticateResult Result { get; set; }

        public string TargetUrl { get; set; }

        public bool Success  { get; set; }

        public bool unAuthorizedRequest { get; set; }
    }

    public class FunzaDirectAuthenticateResult
    {
        public string accessToken { get; set; }

        public string encryptedAccessToken { get; set; }

        public int expireInSeconds { get; set; }

        public int userId { get; set; }
    }
}
