using System;
using System.Collections.Generic;
using System.Text;

namespace FocusApplication.Business.Commands.FileRepository.FileArguments
{
    public class FileAreaEnum
    {
        public class PersonArea
        {
            public static string AreaName = nameof(FileAreaEnum.Enum.PERSON);
            public static string Avatar = nameof(Enum.PERSON_AVATAR);

            public enum Enum
            {
                PERSON_AVATAR
            }
        }

        public class ProductArea
        {
            public static string AreaName = nameof(FileAreaEnum.Enum.PRODUCT);
            public static string Media = nameof(Enum.Media);

            public enum Enum
            {
                Media
            }
        }

        public class CompanyArea
        {
            public static string AreaName = nameof(FileAreaEnum.Enum.COMPANY);
            public static string Avatar = nameof(Enum.COMPANY_AVATAR);

            public enum Enum
            {
                COMPANY_AVATAR
            }
        }

        public enum Enum
        {
            PERSON,

            COMPANY,

            PRODUCT
        }
    }
}
