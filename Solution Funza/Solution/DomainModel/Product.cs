﻿using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Product : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }
        public int FunzaId { get; set; }
        public Guid? IntegrationId { get; set; }

        public int SpecieId { get; set; }
        public int VariatyId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public int ReferenceId { get; set; }
        public string ReferenceCode { get; set; }
        public string ReferenceDescription { get; set; }

        public int ReferenceTypeId { get; set; }
        public string ReferenceTypeName { get; set; }

        public bool SendQuotator { get; set; }

        public DateTime FunzaUpdatedDate { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
