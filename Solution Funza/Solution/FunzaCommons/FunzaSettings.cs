using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaCommons
{
    public class FunzaSettings
    {
        public Dictionary<string, FunzaAuthenticationSettings> AuthenticationSettingsCollection { get; } = new Dictionary<string, FunzaAuthenticationSettings>();

        public string GetProductsURL { get; set; }

        public string GetColorsURL { get; set; }

        public string GetCategoriesURL { get; set; }

        public string GetPackingsURL { get; set; }

        public string GetQuotesURL { get; set; }
    }

    
    

    

}
