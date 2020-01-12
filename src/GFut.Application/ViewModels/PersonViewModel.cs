using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GFut.Application.ViewModels
{
    public class PersonViewModel : BaseEntity
    {
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public string Cpf { get; set; }

        [Display(Name = "Rg")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public string Rg { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Display(Name = "Foto")]
        public string Picture { get; set; }

        string sSenha;

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password
        {
            get
            {
                if (string.IsNullOrEmpty(sSenha))
                {
                    return sSenha;
                }
                //return Diverso.GenerateMD5(sSenha);
                return sSenha;
            }
            set
            {
                sSenha = value;
            }

        }

        [Display(Name = "Ativo")]
        public bool Active { get; set; }

        [Display(Name = "Confirmação")]
        public bool Confirmation { get; set; }

        public string SecurityStamp { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        public DateTime RegisterDate { get; set; }

        public string IdPush { get; set; }

        [NotMapped]
        public string Token { get; set; }

        //public ICollection<PersonProfile> PessoaPerfis { get; set; }
        //public virtual ICollection<Team> Teams { get; set; }
        //public virtual ICollection<Field> Field { get; set; }

    }
}
