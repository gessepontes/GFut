namespace GFut.Domain.Models
{
    public class Horary : BaseEntity
    {
        public int IdFieldItem { get; set; }
        public string Description { get; set; }
        public int DayWeek { get; set; }

        public virtual FieldItem FieldItem { get; set; }
    }
}
