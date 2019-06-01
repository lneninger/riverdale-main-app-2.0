using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class AbstractBaseEntity
    {
        public DateTime? CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }
    }
}
