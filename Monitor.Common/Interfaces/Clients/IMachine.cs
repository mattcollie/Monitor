using System.Collections.Generic;
using Monitor.Common.Dto;

namespace Monitor.Common.Interfaces.Clients
{
    public interface IMachine : IClient
    {
        EnvironmentDto Environment { get; set; }
        IList<TableDto> Tables { get; }
        void SetTables(IList<TableDto> tables);
        TableDto GetTable(TableDto table);
        void UpdateRowCount(TableDto table);
    }
}