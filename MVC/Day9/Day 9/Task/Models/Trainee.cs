using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;
using System;

namespace Task.Models
{
    public enum Gender { Male, Female }

    public class Trainee
    {
        // Trainee ID
        [Key]
        public int ID { get; set; }

        // Trainee Name 
        [Required(ErrorMessage = "You must enter your name")]
        [MaxLength(30, ErrorMessage = "Too long Name char!!!!!!")]
        [Display(Name = "TraineeName")]
        public string Name { get; set; }

        // Gender
        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender gender { get; set; }

        // Email
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter Email....")]
        public string Email { get; set; }

        // Phone Number
        [DataType(DataType.PhoneNumber)]
        public string PhoneNum { get; set; }

        // BirthDate
        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BDate { get; set; }

        [ForeignKey("Course")]
        public int CID { get; set; }

        public virtual Course? Course { get; set; }

        [ForeignKey("Track")]
        public int TrackID { get; set; }

        public virtual Track? Track { get; set; }

    }
}
