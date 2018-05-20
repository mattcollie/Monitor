namespace Monitor.Common.Dto
{
    public class TableDto
    {
        public string Name { get; set; }
        public long RowCount
        {
            get => _rowCount;
            set
            {
                LastRowCount = _rowCount;
                _rowCount = value;
            }
        }

        private long _rowCount;
    
        public long LastRowCount { get; set; }
    }
}