using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
