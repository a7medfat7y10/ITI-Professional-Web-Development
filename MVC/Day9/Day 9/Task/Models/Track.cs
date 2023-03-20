using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Track
    {
        // Track ID
        [Key]
        public int TrackID { get; set; }

        // Track Name
        [Required(ErrorMessage = "You must enter Track name")]
        [MaxLength(30, ErrorMessage = "Too long Name char!!!!!!")]
        public string TrackName { get; set; }

        public string Description { get; set; }

    }
}
