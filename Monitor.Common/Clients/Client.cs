using Monitor.Common.Interfaces.Clients;

namespace Monitor.Common.Clients
{
    public class Client : IClient
    {
        public string ConnectionId { get; set; }
        public string Name { get; set; }
    }
}