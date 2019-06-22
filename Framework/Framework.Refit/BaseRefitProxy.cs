using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
namespace Framework.Refit
{
    public class BaseRefitProxy<T>: DispatchProxy where T: IRefitClient
    {
        private T _decorated;

        public T Original { get; }

        public IRefitClientConfigurator ClientConfigurator { get; set; }

        public BaseRefitProxy()
        {
        }

        public BaseRefitProxy(T original, IRefitClientConfigurator clientConfigurator)
        {
            this.Original = original;
            this.ClientConfigurator = clientConfigurator;
        }

        public T Create()
        {
            object proxy = Create<T, BaseRefitProxy<T>>();
            ((BaseRefitProxy<T>)proxy).SetParameters(this.Original, this.ClientConfigurator);

            return (T)proxy;
        }

        private void SetParameters(T decorated, IRefitClientConfigurator clientConfigurator)
        {
            if (decorated == null)
            {
                throw new ArgumentNullException(nameof(decorated));
            }
            _decorated = decorated;
            this.ClientConfigurator = clientConfigurator;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args) {
            if (targetMethod != null)
            {
                try
                {
                    //try
                    //{
                    //    LogBefore(targetMethod, args);
                    //}
                    //catch (Exception ex)
                    //{
                    //    //Do not stop method execution if exception
                    //    LogException(ex);
                    //}
                    if (this.ClientConfigurator != null)
                    {
                        this.ClientConfigurator.SetFunzaToken(this._decorated).GetAwaiter().GetResult();
                    }
                    var result = targetMethod.Invoke(_decorated, args);
                    //var resultTask = result as Task;
                    //if (resultTask != null)
                    //{
                    //    resultTask.ContinueWith(task =>
                    //    {
                    //        if (task.Exception != null)
                    //        {
                    //            LogException(task.Exception.InnerException ?? task.Exception, targetMethod);
                    //        }
                    //        else
                    //        {
                    //            object taskResult = null;
                    //            if (task.GetType().GetTypeInfo().IsGenericType &&
                    //                task.GetType().GetGenericTypeDefinition() == typeof(Task<>))
                    //            {
                    //                var property = task.GetType().GetTypeInfo().GetProperties()
                    //                    .FirstOrDefault(p => p.Name == "Result");
                    //                if (property != null)
                    //                {
                    //                    taskResult = property.GetValue(task);
                    //                }
                    //            }
                    //            LogAfter(targetMethod, args, taskResult);
                    //        }
                    //    },
                    //        _loggingScheduler);
                    //}
                    //else
                    //{
                    //    try
                    //    {
                    //        LogAfter(targetMethod, args, result);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        //Do not stop method execution if exception
                    //        LogException(ex);
                    //    }
                    //}
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException ?? ex;

                    //if (ex is TargetInvocationException)
                    //{
                    //    LogException(ex.InnerException ?? ex, targetMethod);
                    //    throw ex.InnerException ?? ex;
                    //}
                }
            }

            throw new ArgumentException(nameof(targetMethod));
        }
    }
}
