using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Grower : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string GrowerTypeId { get; set; }
        public Grower GrowerType { get; set; }

        public int OriginId { get; set; }
        public Location Origin { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
