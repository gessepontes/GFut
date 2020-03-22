using System;

namespace GFut.Domain.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Picture { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}