using System;
using System.Collections.Generic;
using System.Text;

namespace FocusServices.Business.Interfaces
{
    public interface IBusinessService
    {
        IEnumerable<T> GetAll<T>() where T : class, new();
        T GetById<T>() where T : class, new();
    }
}
