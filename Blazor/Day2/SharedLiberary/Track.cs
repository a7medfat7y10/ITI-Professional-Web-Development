using System.ComponentModel.DataAnnotations;

namespace SharedLiberary
{
    public class Track
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Too long Name!!")]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }


        public virtual ICollection<Trainee>? Trainees { get; set;}=new HashSet<Trainee>();    

    }
}