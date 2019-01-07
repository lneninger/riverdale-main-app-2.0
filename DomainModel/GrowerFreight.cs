using System;

namespace DomainModel
{
    public class GrowerFreight : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public int GrowerId { get; set; }
        public virtual Grower Grower { get; set; }

        public decimal BasicFreight { get; set; }
        public decimal HolidayFreight { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }

        
    }
}