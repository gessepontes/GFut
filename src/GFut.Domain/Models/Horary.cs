namespace GFut.Domain.Models
{
    public class Horary : BaseEntity
    {
        public int FieldItemId { get; set; }
        public string Description { get; set; }
        public int DayWeek { get; set; }

        public virtual FieldItem FieldItem { get; set; }
    }
}
