using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class FieldViewModel : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public decimal Value { get; set; }
        public decimal MonthlyValue { get; set; }
        public bool Scheduled { get; set; }
        public int PersonId { get; set; }
        public int CityId { get; set; }
    }
}
