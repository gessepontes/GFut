
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GFut.Domain.Models
{
    public class Field : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Fone { get; set; }
        public decimal Value { get; set; }
        public decimal MonthlyValue { get; set; }
        public bool Scheduled { get; set; }
        public string Picture { get; set; }
        public int PersonId { get; set; }
        public int CityId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<FieldItem> FieldItens { get; set; }
        public virtual ICollection<Championship> Championship { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual Match Match { get; set; }
    }
}
