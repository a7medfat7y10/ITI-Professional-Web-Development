using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Task_1.Models
{
    public enum Gender { Male, Female }
    public class Customer
    {
        // Customer ID
        [Key]
        public int CID { get; set; }

        // Customer Name 
        [Required(ErrorMessage = "You must enter your name")]
        [MaxLength(30, ErrorMessage = "Too long Name char!!!!!!")]
        [Display(Name = "CustomerName")]
        public string CName { get; set; }

        // Gender
        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Cgender { get; set; }

        // Email
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter Email....")]
        public string Email { get; set; }

        // Phone Number
        [DataType(DataType.PhoneNumber)]
        public string PhoneNum { get; set; }
    }
}