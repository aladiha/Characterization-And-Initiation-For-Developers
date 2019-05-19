using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.hubs
{
    public class NoteHub : Hub
    {
        public static void Show() {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NoteHub>();
            context.Clients.All.displayStatus();
         }


    }
}