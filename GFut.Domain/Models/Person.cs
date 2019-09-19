using System;
using System.Collections.Generic;

namespace GFut.Domain.Models
{
    public class Person : BaseEntity
    {
        public Person()
        {
            Teams = new HashSet<Team>();
            PersonProfiles = new HashSet<PersonProfile>();
        }

        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime BirthDate { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string Password { get; set; }
        public bool Confirmation { get; set; }
        public string SecurityStamp { get; set; }
        public string IdPush { get; set; }
        public string Token { get; set; }


        public ICollection<PersonProfile> PersonProfiles { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Field> Field { get; set; }
    }
}