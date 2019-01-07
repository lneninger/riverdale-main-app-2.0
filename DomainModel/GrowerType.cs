using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class GrowerType : AbstractBaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Grower> Growers { get; set; }
    }
}
