using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Xml.Linq;

namespace Task_2.Models
{
    public enum Gender { Male, Female }
    public class Student
    {
        // Student ID
        [Key]
        public int StdID { get; set; }

        // Student Name 
        [Required(ErrorMessage = "You must enter your name")]
        [MaxLength(30, ErrorMessage = "Too long Name char!!!!!!")]
        [Display(Name = "StdName")]
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

        public virtual Course Course { get; set; }
    }
}
