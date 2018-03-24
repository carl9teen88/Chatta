using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chatta.Services.Interface;
using Microsoft.AspNet.SignalR;

namespace Chatta.Chat
{
    public class ChatHub : Hub
    {
        public void Send(object message, string type = "string")
        {
            Clients.Others.Send(message, type);
        }
    }
}