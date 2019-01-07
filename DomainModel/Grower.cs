using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Grower : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string GrowerTypeId { get; set; }
        public virtual GrowerType GrowerType { get; set; }

        public int OriginId { get; set; }
        public virtual Location Origin { get; set; }

        public virtual IEnumerable<GrowerFreight> GrowerFreights { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
