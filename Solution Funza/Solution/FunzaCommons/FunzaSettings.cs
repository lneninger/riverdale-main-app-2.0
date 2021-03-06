﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FunzaCommons
{
    public class FunzaSettings
    {
        public string FunzaBaseURL { get; set; }

        public string AuthenticationRelativeURL { get; set; }
        public string QuotesRelativeURL { get; set; }
        public string SeasonsRelativeURL { get; set; }
        public string GoodPricesRelativeURL { get; set; }
        public string PackagePricesRelativeURL { get; set; }
        public string ProductColorRelativeURL { get; set; }
        public string ProductsRelativeURL { get; set; }
        public string PackingRelativeURL { get; set; }
        public string ProductCategoryRelativeURL { get; set; }

        public Dictionary<string, FunzaAuthenticationSettings> AuthenticationSettingsCollection { get; } = new Dictionary<string, FunzaAuthenticationSettings>();

        //public string GetProductsURL { get; set; }

        //public string GetColorsURL { get; set; }

        //public string GetCategoriesURL { get; set; }

        //public string GetPackingsURL { get; set; }

        public string GetQuotesURL { get; set; }
    }

    
    

    

}
