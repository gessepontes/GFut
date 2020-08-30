namespace GFut.Domain.Models
{
    public class Horary : BaseEntity
    {
        public int FieldItemId { get; set; }
        public string Hour { get; set; }
        public int DayWeek { get; set; }
        public bool State { get; set; }

        public virtual FieldItem FieldItem { get; set; }
    }
}
