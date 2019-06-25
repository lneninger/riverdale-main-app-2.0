using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Category : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }
        public int FunzaId { get; set; }
        public Guid? IntegrationId { get; set; }

        public string Name { get; set; }

        public bool ToOrder { get; set; }

        public bool ToStem { get; set; }

        public string FunzaCreatedBy { get; set; }

        public DateTime FunzaCreatedDate { get; set; }

        public string FunzaUpdatedBy { get; set; }

        public DateTime? FunzaUpdatedDate { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
