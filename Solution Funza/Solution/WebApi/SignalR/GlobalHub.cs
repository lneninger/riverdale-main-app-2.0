using Framework.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.SignalR
{
    public interface IGlobalHub
    {
        Task DataChanged(SignalREventArgs @event);
    }

    public class GlobalHub : Hub<IGlobalHub>
    {
    }
}
