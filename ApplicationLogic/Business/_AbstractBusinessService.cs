using ApplicationLogic.Business.Interfaces;
using Framework.Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business
{
    public abstract class AbstractBusinessService : BaseIoCDisposable, IBusinessService
    {
        public abstract IEnumerable<T> GetAll<T>() where T : class, new();

        public abstract T GetById<T>() where T : class, new();
    }
}
