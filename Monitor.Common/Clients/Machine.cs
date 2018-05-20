using System.Collections.Generic;
using System.Linq;
using Monitor.Common.Dto;
using Monitor.Common.Interfaces;
using Monitor.Common.Interfaces.Clients;

namespace Monitor.Common.Clients
{
    public class Machine : Client, IMachine
    {
        public EnvironmentDto Environment { get; set; }
        public IList<TableDto> Tables { get; } = new List<TableDto>();

        public void SetTables(IList<TableMapDto> tables)
        {
            foreach (TableMapDto map in tables)
            {
                Tables.Add(new TableDto
                {
                    MapId = map.Id,
                    Name = map.Name,
                    RowCount = 0
                });
            }
        }

        public void UpdateTableMap(TableMapDto table)
        {
            TableDto clientTable = GetTable(table);
            if (clientTable == null)
            {
                clientTable = new TableDto
                {
                    MapId = table.Id
                };
                Tables.Add(clientTable);
            }
            clientTable.Name = table.Name;
        }

        public TableDto GetTable(IBaseDto table)
        {
            return Tables.FirstOrDefault(t => t.MapId == table.Id);
        }

        public void UpdateRowCount(TableUpdateDto table)
        {
            TableDto clientTable = GetTable(table);
            if (clientTable == null)
            {
                clientTable = new TableDto
                {
                    MapId = table.Id,
                    Name = $"Unknown Table[{table.Id}]",
                    UnknownTable = true,
                    RowCount = table.RowCount
                };
                Tables.Add(clientTable);
            }
            clientTable.RowCount = table.RowCount;
        }
    }
}