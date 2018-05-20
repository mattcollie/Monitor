using System.Collections.Generic;
using System.Linq;
using Monitor.Common.Dto;
using Monitor.Common.Interfaces.Clients;

namespace Monitor.Common.Clients
{
    public class Machine : Client, IMachine
    {
        public EnvironmentDto Environment { get; set; }
        public IList<TableDto> Tables { get; private set; }

        public void SetTables(IList<TableDto> tables)
        {
            Tables = tables;
        }

        public TableDto GetTable(TableDto table)
        {
            return Tables.FirstOrDefault(t => t.Name == table.Name);
        }

        public void UpdateRowCount(TableDto table)
        {
            TableDto clientTable = GetTable(table);
            clientTable.RowCount = table.RowCount;
        }
    }
}