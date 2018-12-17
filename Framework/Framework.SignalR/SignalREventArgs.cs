using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.SignalR
{
    public class SignalREventArgs
    {
        string EventName { get; set; }

        string EntityName { get; set; }

        object Entity { get; set; }
    }
}
