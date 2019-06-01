using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Quote : AbstractBaseEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
    }
}
