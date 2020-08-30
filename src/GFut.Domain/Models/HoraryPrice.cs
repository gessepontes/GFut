using System;

namespace GFut.Domain.Models
{
    public class HoraryPrice : BaseEntity
    {
        public int FieldItemId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal Value { get; set; }
        public decimal MonthlyValue { get; set; }

        public virtual FieldItem FieldItem { get; set; }
    }
}
