using DomainModel.Product;
using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.SaleOpportunity
{
    public class SaleOpportunityTargetPriceProduct : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }

        public int ProductAmount { get; set; }

        public int ProductId { get; set; }
        public virtual AbstractProduct Product { get; set; }

        public int SaleOpportunityTargetPriceId { get; set; }
        public virtual SaleOpportunityTargetPrice SaleOpportunityTargetPrice { get; set; }

        public string ProductColorTypeId { get; set; }
        public virtual ProductColorType ProductColorType { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
