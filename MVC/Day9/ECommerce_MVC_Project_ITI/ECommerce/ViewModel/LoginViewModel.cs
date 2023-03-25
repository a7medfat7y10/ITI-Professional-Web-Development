using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool isPersisite { get; set; }
    }
}
