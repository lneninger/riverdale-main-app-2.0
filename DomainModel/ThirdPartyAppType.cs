using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class ThirdPartyAppType: AbstractBaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
