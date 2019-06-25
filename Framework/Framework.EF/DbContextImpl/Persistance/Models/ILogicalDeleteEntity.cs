using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.EF.DbContextImpl.Persistance
{
    public interface ILogicalDeleteEntity
    {
        DateTime? DeletedAt { get; set; }

        bool? IsDeleted { get; set; }
    }
}
