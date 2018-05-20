using System;

namespace Monitor.Common.Interfaces.Clients
{
    public interface IClient
    {
        string ConnectionId { get; set; }
        string Name { get; set; }
        DateTime ConnectedTime { get; }
    }
}