using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [DisplayName("Active")]
        public bool Active { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public DateTime RegisterDate { get; set; }
    }
}
