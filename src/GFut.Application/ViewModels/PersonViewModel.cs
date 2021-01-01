using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GFut.Application.ViewModels
{
    public class PersonViewModel : BaseEntity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }

        string sSenha;
        public string Password
        {
            get
            {
                if (string.IsNullOrEmpty(sSenha))
                {
                    return sSenha;
                }
                return sSenha;
            }
            set
            {
                sSenha = value;
            }

        }

        public bool Confirmation { get; set; }
        public string SecurityStamp { get; set; }
        public bool Status { get; set; }
        public string IdPush { get; set; }

        [NotMapped]
        public string Token { get; set; }

        public List<string> ProfileType { get; set; }
        public virtual TeamViewModel Team { get; set; }
        public virtual List<PageProfileViewModel> PageProfiles { get; set; }


    }
}
