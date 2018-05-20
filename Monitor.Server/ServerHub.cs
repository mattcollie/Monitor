using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Monitor.Common.Dto;
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

        public void SetEnvironment(string name)
        {
            IMachine client = Context.GetClientByContext<IMachine>();
            client.Environment = new EnvironmentDto { Name = name };
        }

        public void SetTables(IList<TableMapDto> tables)
        {
            IMachine client = Context.GetClientByContext<IMachine>();
            client.SetTables(tables);
        }

        public void UpdateTableMap(TableMapDto table)
        {
            IMachine client = Context.GetClientByContext<IMachine>();
            client.UpdateTableMap(table);
        }

        public void UpdateRowCount(TableUpdateDto table)
        {
            IMachine client = Context.GetClientByContext<IMachine>();
            client.UpdateRowCount(table);
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