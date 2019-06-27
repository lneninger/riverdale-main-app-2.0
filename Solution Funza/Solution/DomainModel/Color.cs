using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Color : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }
        public int FunzaId { get; set; }
        public Guid? IntegrationId { get; set; }

        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public bool Status { get; set; }
        public string Version { get; set; }
        public string Hexagecimal { get; set; }
        public string Image { get; set; }

        public string FunzaCreatedBy { get; set; }
        public DateTime FunzaCreatedDate { get; set; }
        public string FunzaUpdatedBy { get; set; }
        public DateTime FunzaUpdatedDate { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
