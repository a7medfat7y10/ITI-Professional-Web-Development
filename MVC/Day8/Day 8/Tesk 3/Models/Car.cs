using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_1.Models
{
    public class Car
    {
        [MaxLength(10)]
        public int Num { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string Manufacture { get; set; }
    }
}


