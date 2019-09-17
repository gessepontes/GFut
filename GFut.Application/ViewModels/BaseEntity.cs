using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
