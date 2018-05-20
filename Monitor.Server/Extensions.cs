using Microsoft.AspNet.SignalR.Hubs;
using Monitor.Common.Interfaces.Clients;

namespace Monitor.Server
{
    public static class Extensions
    {
        public static TClient GetClientByContext<TClient>(this HubCallerContext context) where TClient : class, IClient
        {
            return Server.Instance.GetClient<TClient>(context.ConnectionId);
        }
    }
}