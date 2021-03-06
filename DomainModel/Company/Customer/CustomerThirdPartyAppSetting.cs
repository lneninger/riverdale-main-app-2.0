﻿using DomainModel._Commons.Enums;
using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Company.Customer
{
    public class CustomerThirdPartyAppSetting : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public string ThirdPartyAppTypeId { get; set; }
        public virtual ThirdPartyAppType ThirdPartyAppType { get; set; }

        public ThirdPartyAppTypeEnum.Enum? ThirdPartyAppTypeEnum
        {
            get
            {
                if (Enum.TryParse(typeof(ThirdPartyAppTypeEnum.Enum), this.ThirdPartyAppTypeId, out object value))
                {
                    return (ThirdPartyAppTypeEnum.Enum?)value;
                }

                return null;
            }
            set
            {
                this.ThirdPartyAppTypeId = (value != null) ? value.ToString() : null;
            }
        }

        public string ThirdPartyCustomerId { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
