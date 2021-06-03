using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Utilities.Configurations
{
    public static class Configuration
    {
        public static string BackendURL { get; set; } = "https://saveyourappdevelopment.azurewebsites.net";
        public static string Token { get; set; }
        public static string NotificationURL { get; set; } = "Endpoint=sb://saveyourapptest.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=0EcBaSOfn6/PY2UN5TS5uRQtba7HhXX9EL1C8+ZLI1M=";
        public static string NotificaitonHubName { get; set; } = "saveyourapptest";
        public static string SignalRURL { get; set; } = "https://saveyourappdevelopment.azurewebsites.net/chathub";
    }
}
