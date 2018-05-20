using Monitor.Common.Interfaces;

namespace Monitor.Common.Dto
{
    public class TableMapDto : IBaseDto
    {
        public string Name { get; set; }
        public long Id { get; set; }
    }
}