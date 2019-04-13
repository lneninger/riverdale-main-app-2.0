using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverdaleMainApp2_0.Auth
{
    public class PermissionsEnum
    {
        // Customer
        /// <summary>
        /// 
        /// </summary>
        public const string Customer_Read = nameof(Enum.Customer_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string Customer_Modify = nameof(Enum.Customer_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string Customer_Manage = nameof(Enum.Customer_Manage);

        // Grower
        /// <summary>
        /// 
        /// </summary>
        public const string Grower_Read = nameof(Enum.Grower_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string Grower_Modify = nameof(Enum.Grower_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string Grower_Manage = nameof(Enum.Grower_Manage);

        // Flower Product Category
        /// <summary>
        /// 
        /// </summary>
        public const string ProductCategory_Read = nameof(Enum.FlowerProductCategory_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string ProductCategory_Modify = nameof(Enum.FlowerProductCategory_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string ProductCategory_Manage = nameof(Enum.ProductCategory_Manage);


        // Product
        /// <summary>
        /// 
        /// </summary>
        public const string Product_Read = nameof(Enum.Product_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string Product_Modify = nameof(Enum.Product_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string Product_Manage = nameof(Enum.Product_Manage);

        // Product Color
        /// <summary>
        /// 
        /// </summary>
        public const string ProductColor_Read = nameof(Enum.ProductColor_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string ProductColor_Modify = nameof(Enum.ProductColor_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string ProductColor_Manage = nameof(Enum.ProductColor_Manage);

        // User
        /// <summary>
        /// 
        /// </summary>
        public const string User_Read = nameof(Enum.User_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string User_Modify = nameof(Enum.User_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string User_Manage = nameof(Enum.User_Manage);

        // User Role
        /// <summary>
        /// 
        /// </summary>
        public const string UserRole_Read = nameof(Enum.UserRole_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string UserRole_Modify = nameof(Enum.UserRole_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string UserRole_Manage = nameof(Enum.UserRole_Manage);


        // Sale Opportunity
        /// <summary>
        /// 
        /// </summary>
        public const string SaleOpportunity_Read = nameof(Enum.SaleOpportunity_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string SaleOpportunity_Modify = nameof(Enum.SaleOpportunity_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string SaleOpportunity_Manage = nameof(Enum.SaleOpportunity_Manage);

        // Sale Opportunity Price Level
        /// <summary>
        /// 
        /// </summary>
        public const string SaleOpportunityTargetPrice_Read = nameof(Enum.SaleOpportunityTargetPrice_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string SaleOpportunityTargetPrice_Modify = nameof(Enum.SaleOpportunityTargetPrice_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string SaleOpportunityTargetPrice_Manage = nameof(Enum.SaleOpportunityTargetPrice_Manage);


         // Sale Opportunity Target Price Product
        /// <summary>
        /// 
        /// </summary>
        public const string SaleOpportunityTargetPriceProduct_Read = nameof(Enum.SaleOpportunityTargetPriceProduct_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string SaleOpportunityTargetPriceProduct_Modify = nameof(Enum.SaleOpportunityTargetPriceProduct_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string SaleOpportunityTargetPriceProduct_Manage = nameof(Enum.SaleOpportunityTargetPriceProduct_Manage);


        

        // Quote
        /// <summary>
        /// 
        /// </summary>
        public const string Quote_Read = nameof(Enum.Quote_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string Quote_Modify = nameof(Enum.Quote_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string Quote_Manage = nameof(Enum.Quote_Manage);

        // Funza
        /// <summary>
        /// 
        /// </summary>
        public const string Funza_Read = nameof(Enum.Funza_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string Funza_Modify = nameof(Enum.Funza_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string Funza_Manage = nameof(Enum.Funza_Manage);

        // Settings
        /// <summary>
        /// 
        /// </summary>
        public const string Settings_Read = nameof(Enum.Settings_Read);

        /// <summary>
        /// 
        /// </summary>
        public const string Settings_Modify = nameof(Enum.Settings_Modify);

        /// <summary>
        /// 
        /// </summary>
        public const string Settings_Manage = nameof(Enum.Settings_Manage);


        /// <summary>
        /// 
        /// </summary>
        public enum Enum
        {
            // Customer
            /// <summary>
            /// 
            /// </summary>
            Customer_Read,

            /// <summary>
            /// 
            /// </summary>
            Customer_Modify,

            /// <summary>
            /// 
            /// </summary>
            Customer_Manage,

            // Grower
            /// <summary>
            /// 
            /// </summary>
            Grower_Read,

            /// <summary>
            /// 
            /// </summary>
            Grower_Modify,

            /// <summary>
            /// 
            /// </summary>
            Grower_Manage,

            // Flower Product Category

            /// <summary>
            /// 
            /// </summary>
            FlowerProductCategory_Read,

            /// <summary>
            /// 
            /// </summary>
            FlowerProductCategory_Modify,

            /// <summary>
            /// 
            /// </summary>
            ProductCategory_Manage,

            // Product

            /// <summary>
            /// 
            /// </summary>
            Product_Read,

            /// <summary>
            /// 
            /// </summary>
            Product_Modify,

            /// <summary>
            /// 
            /// </summary>
            Product_Manage,

            // Product Color

            /// <summary>
            /// 
            /// </summary>
            ProductColor_Read,

            /// <summary>
            /// 
            /// </summary>
            ProductColor_Modify,

            /// <summary>
            /// 
            /// </summary>
            ProductColor_Manage,

            // User
            /// <summary>
            /// 
            /// </summary>
            User_Read,

            /// <summary>
            /// 
            /// </summary>
            User_Modify,

            /// <summary>
            /// 
            /// </summary>
            User_Manage,

            // User Role
            /// <summary>
            /// 
            /// </summary>
            UserRole_Read,

            /// <summary>
            /// 
            /// </summary>
            UserRole_Modify,

            /// <summary>
            /// 
            /// </summary>
            UserRole_Manage,

            // Quote
            /// <summary>
            /// 
            /// </summary>
            Quote_Read,

            /// <summary>
            /// 
            /// </summary>
            Quote_Modify,

            /// <summary>
            /// 
            /// </summary>
            Quote_Manage,

            /// <summary>
            /// 
            /// </summary>
            SaleOpportunity_Read,

            /// <summary>
            /// 
            /// </summary>
            SaleOpportunity_Modify,

            /// <summary>
            /// 
            /// </summary>
            SaleOpportunity_Manage,

            /// <summary>
            /// 
            /// </summary>
            SaleOpportunityTargetPrice_Read,

            /// <summary>
            /// 
            /// </summary>
            SaleOpportunityTargetPrice_Modify,

            /// <summary>
            /// 
            /// </summary>
            SaleOpportunityTargetPrice_Manage,

            /// <summary>
            /// 
            /// </summary>
            SaleOpportunityTargetPriceProduct_Read,

            /// <summary>
            /// 
            /// </summary>
            SaleOpportunityTargetPriceProduct_Modify,

            /// <summary>
            /// 
            /// </summary>
            SaleOpportunityTargetPriceProduct_Manage,

            // Funza
            /// <summary>
            /// 
            /// </summary>
            Funza_Read,

            /// <summary>
            /// 
            /// </summary>
            Funza_Modify,

            /// <summary>
            /// 
            /// </summary>
            Funza_Manage,

            // Settings
            /// <summary>
            /// 
            /// </summary>
            Settings_Read,

            /// <summary>
            /// 
            /// </summary>
            Settings_Modify,

            /// <summary>
            /// 
            /// </summary>
            Settings_Manage,
        }
    }
}
