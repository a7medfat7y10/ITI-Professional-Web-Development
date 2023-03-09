using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;
using System.Xml.Linq;

namespace Task_1.Models
{
    public enum Gender { Male, Female }

    public class Employee
    {
        // Employee ID
        [Key]
        public int empID { get; set; }

        // Employee Name 
        [Required(ErrorMessage = "You must enter your name")]
        [MaxLength(30, ErrorMessage = "Too long Name char!!!!!!")]
        [Display(Name = "EmployeeName")]
        public string empName { get; set; }

        // User Name 
        [Required(ErrorMessage = "You must enter your name")]
        [MaxLength(10, ErrorMessage = "10 char maximum")]
        [Display(Name = "UserName")]
        public string Username { get; set; }

        // Password
        [Required(ErrorMessage = "You Must Enter Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Gender
        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Empgender { get; set; }

        // Salary
        public int Salary { get; set; }

        // Join Date
        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime JoinDate { get; set; }

        // Email
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter Email....")]
        public string Email { get; set; }

        // Phone Number
        [DataType(DataType.PhoneNumber)]
        public string PhoneNum { get; set; }

    }
}