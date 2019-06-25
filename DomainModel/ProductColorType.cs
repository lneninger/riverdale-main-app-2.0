using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class ProductColorType : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string HexCode { get; set; }

        public bool IsBasicColor { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
