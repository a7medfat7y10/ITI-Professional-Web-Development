using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Course
    {
        // Course ID
        [Key]
        public int CID { get; set; }

        // Topic Name
        [Required(ErrorMessage = "You must enter Course name")]
        [MaxLength(30, ErrorMessage = "Too long Name char!!!!!!")]
        public string CName { get; set; }

        [Required]
        public string CGrade { get; set; }
    }
}
