using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static GFut.Domain.Others.Enum;

namespace GFut.Application.ViewModels
{
    public class PlayerViewModel : BaseEntity
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Picture { get; set; }
        public string Phone { get; set; }
        public Position Position { get; set; }
        public bool Dispensed { get; set; }
        public DateTime? DispenseDate { get; set; }
    }
}
