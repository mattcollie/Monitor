using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitor.Common.Clients;
using Monitor.Common.Interfaces.Clients;

namespace Monitor.Server
{
    public class Server
    {
        private static readonly Lazy<Server> _instance = new Lazy<Server>(() => new Server(GlobalHost.ConnectionManager.GetHubContext<ServerHub>().Clients));
        public static Server Instance => _instance.Value;
        
        public IHubConnectionContext<dynamic> HubClients { get; }
        public readonly IDictionary<string, IClient> Clients = new Dictionary<string, IClient>();

        private Server(IHubConnectionContext<dynamic> hubClients)
        {
            HubClients = hubClients;
        }

        public TClient GetClient<TClient>(string clientId) where TClient : class, IClient
        {
            if (Clients.ContainsKey(clientId)) return default(TClient);
            
            return Clients[clientId] as TClient;
        }

        public IList<TClient> GetAll<TClient>() where TClient : class, IClient
        {
            return Clients.Where(c => c.Value is TClient).Select(c => c.Value as TClient).ToList();
        }

        #region Clients
        
        public void Add(string clientId)
        {
            // add new client
            Clients.Add(clientId, new Client
            {
                ConnectionId = clientId
            });
        }

        public void Remove(string clientId)
        {
            // client not found, no more work
            if (!Clients.ContainsKey(clientId)) return;
            
            // remove the client
            Clients.Remove(clientId);
        }

        public void RegisterAs<TClient>(TClient client) where TClient : class, IClient
        {
            // we don't want anymore than 10 reporters...
            // because that's a lot of connections..
            // we can kick the oldest one
            if (GetAll<IReporter>().Count >= 10)
            {
                // get the oldest reporter
                IReporter oldest = GetAll<IReporter>().OrderBy(c => c.ConnectedTime).FirstOrDefault();
                if (oldest != null)
                {
                    // remove the oldest reporter
                    Remove(oldest.ConnectionId);
                }
            }
            
            // check if the client exists
            if (Clients.ContainsKey(client.ConnectionId))
            {
                // update the client with the new client type
                Clients[client.ConnectionId] = client;
            }
            else
            {
                // add the client to the client list
                Clients.Add(client.ConnectionId, client);
            }
        }
        #endregion
    }
}