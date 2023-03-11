using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task_1.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        // Date
        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        // Price
        [MinPrice(0)]
        public decimal Price { get; set; }

        // Customer ID, Foreign key
        [ForeignKey("Customer")]
        public int CID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
