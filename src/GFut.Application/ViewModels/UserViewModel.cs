using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class UserViewModel : BaseEntity
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "The Password is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
