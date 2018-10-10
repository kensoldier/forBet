using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApplication1.Hubs
{
    public class BroadcastHub : Hub
    {
        public void Broadcast(string name, string message)
        {
            Clients.All.showmessage(name, message);
        }
    }
}