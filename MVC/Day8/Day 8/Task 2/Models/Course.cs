using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_2.Models
{
    public class Course
    {
        // Course ID
        [Key]
        public int CID { get; set; }

        // Topic Name
        [Required(ErrorMessage = "You must enter Course name")]
        [MaxLength(30, ErrorMessage = "Too long Name char!!!!!!")]
        public string TopicName { get; set; }

        [Required]
        public string CourseGrade { get; set;}
    }
}
