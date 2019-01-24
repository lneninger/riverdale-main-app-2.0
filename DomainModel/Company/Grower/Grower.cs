using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Company.Grower
{
    public class Grower : AbstractCompany
    {
        public string Code { get; set; }

        public string GrowerTypeId { get; set; }
        public virtual GrowerType GrowerType { get; set; }


        public virtual IEnumerable<GrowerFreight> GrowerFreights { get; set; }
    }
}
