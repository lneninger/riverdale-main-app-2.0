using Framework.EF.DbContextImpl.Persistance;
using System;

namespace DomainModel
{
    public class AbstractBaseEntity: ITrackChangesEntity
    {
        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }
    }
}