using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class UserViewModel : BaseEntity
    {
        public string Name { get; set; }
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }

        public string Picture { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
