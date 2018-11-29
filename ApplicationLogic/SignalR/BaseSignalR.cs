using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.SignalR
{
    public class BaseSignalR : Framework.SignalR.BaseHub
    {
        protected override string GetUserName()
        {
            throw new NotImplementedException();
        }
    }
}
