using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel._Commons.Enums
{
    public class ThirdPartyAppTypeEnum
    {
        public const string BusinessERP = nameof(Enum.BISERP);
        public const string Salesforce = nameof(Enum.SFORCE);

        public enum Enum
        {
            BISERP,
            SFORCE
        }

    }
}
