using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Monitor.Common.Interfaces.Clients;

namespace Monitor.Server
{
    public class ServerHub : Hub
    {
        #region Reporter
        public void RegisterAsReporter(string name)
        {
            IReporter client = Context.GetClientByContext<IReporter>();
            client.Name = name;
            
            Server.Instance.RegisterAs<IReporter>(client);
        }
        #endregion

        #region Machine
        public void RegisterAsMachine(string name)
        {
            IMachine client = Context.GetClientByContext<IMachine>();
            client.Name = name;
            
            Server.Instance.RegisterAs<IMachine>(client);
        }
        #endregion
        
        #region Overrides
        public override Task OnConnected()
        {
            // we allow an unlimited amount of connections
            Server.Instance.Add(Context.ConnectionId);
            
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Server.Instance.Remove(Context.ConnectionId);
            
            return base.OnDisconnected(stopCalled);
        }
        #endregion
    }
}