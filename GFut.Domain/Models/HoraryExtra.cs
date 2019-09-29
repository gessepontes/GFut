using System;

namespace GFut.Domain.Models
{
    public class HoraryExtra : BaseEntity
    {
        public int FieldItemId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual FieldItem FieldItem { get; set; }
    }
}
