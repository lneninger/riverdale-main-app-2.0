using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverdaleMainApp2_0.Auth
{
    public class PermissionsEnum
    {
        // Customer
        public const string Customer_Read = nameof(Enum.Customer_Read);
        public const string Customer_Modify = nameof(Enum.Customer_Modify);
        public const string Customer_Manage = nameof(Enum.Customer_Manage);

        // Product
        public const string Product_Read = nameof(Enum.Product_Read);
        public const string Product_Modify = nameof(Enum.Product_Modify);
        public const string Product_Manage = nameof(Enum.Product_Manage);

        // User
        public const string User_Read = nameof(Enum.User_Read);
        public const string User_Modify = nameof(Enum.User_Modify);
        public const string User_Manage = nameof(Enum.User_Manage);

        // User Role
        public const string UserRole_Read = nameof(Enum.UserRole_Read);
        public const string UserRole_Modify = nameof(Enum.UserRole_Modify);
        public const string UserRole_Manage = nameof(Enum.UserRole_Manage);

        // Quote
        public const string Quote_Read = nameof(Enum.Quote_Read);
        public const string Quote_Modify = nameof(Enum.Quote_Modify);
        public const string Quote_Manage = nameof(Enum.Quote_Manage);


        public enum Enum
        {
            // Customer
            Customer_Read,
            Customer_Modify,
            Customer_Manage,

            // Product
            Product_Read,
            Product_Modify,
            Product_Manage,

            // User
            User_Read,
            User_Modify,
            User_Manage,

            // User Role
            UserRole_Read,
            UserRole_Modify,
            UserRole_Manage,

            // Quote
            Quote_Read,
            Quote_Modify,
            Quote_Manage,
        }
    }
}
