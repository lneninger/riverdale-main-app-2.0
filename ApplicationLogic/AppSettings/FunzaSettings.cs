﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.AppSettings
{
    public class FunzaSettings
    {
        public string FunzaUrl { get; set; }

        public string GetProductsURL { get; set; }

        public string GetColorsURL { get;  set; }

        public string GetCategoriesURL { get;  set; }

        public string GetPackingsURL { get;  set; }

        public string GetQuotesURL { get; set; }

        public Dictionary<string, FunzaAuthenticationSettings> AuthenticationSettingsCollection { get; } = new Dictionary<string, FunzaAuthenticationSettings>();
    }

    public class TokenSettings
    {
        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public TimeSpan? ExpiresIn { get; set; }

        public string UserName { get; set; }

        public string Issued { get; set; }

        public DateTime? Expires { get; set; }

    }

    public class FunzaAuthenticationSettings {
        public string AuthenticationURL { get; set; }

        public string AuthenticationUserName { get; set; }

        public string AuthenticationPassword { get; set; }

        public TokenSettings TokenSettings { get; set; }
    }
}
