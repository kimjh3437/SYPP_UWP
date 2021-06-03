using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Utilities.HubConnection
{
    public static class Hubs
    {
        public static Microsoft.AspNetCore.SignalR.Client.HubConnection Connection { get; set; }
    }
}
