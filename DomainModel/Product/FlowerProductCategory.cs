using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class FlowerProductCategory : AbstractBaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<FlowerProduct> Flowers { get; set; }

        public virtual ICollection<FlowerProductCategoryGrade> Grades { get; set; }

        public virtual ICollection<ProductAllowedColorType> AllowedColorTypes { get; set; }

    }
}
