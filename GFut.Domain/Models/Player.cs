
using System;
using System.ComponentModel.DataAnnotations.Schema;
using static GFut.Domain.Others.Enum;

namespace GFut.Domain.Models
{
    public class Player : BaseEntity
    {
        public int IdTeam { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Picture { get; set; }

        [NotMapped]
        public string OldPicture { get; set; }

        public string Fone { get; set; }
        public string Rg { get; set; }
        public Position Position { get; set; }

        public bool Dispensed { get; set; }
        public DateTime DispenseDate { get; set; }

        public Team Team { get; set; }
    }
}