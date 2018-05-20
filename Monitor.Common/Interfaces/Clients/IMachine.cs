using System.Collections.Generic;
using Monitor.Common.Dto;

namespace Monitor.Common.Interfaces.Clients
{
    public interface IMachine : IClient
    {
        EnvironmentDto Environment { get; set; }
        IList<TableDto> Tables { get; }
        void UpdateTableMap(TableMapDto table);
        void SetTables(IList<TableMapDto> tables);
        TableDto GetTable(IBaseDto table);
        void UpdateRowCount(TableUpdateDto table);
    }
}