using DomainModel._Commons.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Company
{
    /// <summary>
    /// 
    /// </summary>
    public class AbstractCompany : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CompanyTypeId { get; set; }

        public virtual CompanyType CompanyType { get; set; }

        public CompanyTypeEnum CompanyTypeEnum { get {
                return (CompanyTypeEnum)Enum.Parse(typeof(CompanyTypeEnum), this.CompanyTypeId);
            }
            set {
                this.CompanyTypeId = value.ToString();
            }
        }


        public int OriginId { get; set; }
        public virtual Location Origin { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }

        //Collections
    }
}
