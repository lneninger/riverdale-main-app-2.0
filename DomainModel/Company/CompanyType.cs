using System.Collections.Generic;

namespace DomainModel.Company
{
    public class CompanyType : AbstractBaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<AbstractCompany> Companies { get; set; }
    }
}