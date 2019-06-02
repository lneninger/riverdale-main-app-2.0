using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaCommons
{
    public class FunzaTokenSettings
    {
        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public TimeSpan? ExpiresIn { get; set; }

        public string UserName { get; set; }

        public string Issued { get; set; }

        public DateTime? Expires { get; set; }

    }
}
