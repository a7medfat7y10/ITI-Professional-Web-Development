using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLiberary
{
    public class Trainee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Too long Name!!")]
        public string? Name { get; set; }

        [Required]
        [DataType(dataType:DataType.EmailAddress, ErrorMessage = "Not A Valid Email!!")]
        public string? Email { get; set; }

        [Required]
        [DataType(dataType: DataType.PhoneNumber, ErrorMessage = "Not A Valid Phone!!")]
        public string MobileNo { get; set; }

        [Required]
        [DataType(dataType: DataType.Date, ErrorMessage = "Not A Valid Date !!")]
        public DateOnly Birthdate { get; set; }
        public Boolean IsGraduated { get; set; }

        [Required]
        [EnumDataType(typeof(Gender),ErrorMessage = "Not A Valid Sex !!")]
        public Gender Sex { get; set; }

        [ForeignKey(nameof(Track))]
        public int  trackId { get; set; }
        public virtual Track? track { get; set; }
    }
}
