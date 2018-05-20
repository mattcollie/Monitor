using Monitor.Common.Interfaces;

namespace Monitor.Common.Dto
{
    public class TableUpdateDto : IBaseDto
    {
        public long Id { get; set; }
        public long RowCount { get; set; }
    }
}