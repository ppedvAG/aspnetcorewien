using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorewien.Pages.Modul10
{
    public class MyChatHub:Hub
    {

        public void Send(string msg)
        {
            Clients.All.SendAsync("ETClient", msg);
        }
    }
}
