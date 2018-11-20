using System;
using System.Collections.Generic;
using System.Text;

namespace FocusApplication.Repositories.DB
{
    public interface IDBRepository<T> where T : class, new()
    {
    }
}
