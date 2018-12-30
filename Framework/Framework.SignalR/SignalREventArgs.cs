using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.SignalR
{
    public class SignalREventArgs
    {
        public SignalREventArgs(string eventName, string entityName, object entity)
        {
            this.EventName = eventName;
            this.EntityName = entityName;
            this.EntityName = entityName;
            this.EntityName = entityName;
            this.Entity = entity;
        }

        public string EventName { get; set; }

        public string EntityName { get; set; }

        public object Entity { get; set; }
    }
}
