using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Task_1.Models
{
    public class CarList
    {
        public static List<Car> Cars { get; set; } = new List<Car>()
        {
            new Car(){ Num = 1, Color = "red", Model = "2022 BMW 7 Series", Manufacture = "BMW" },
            new Car(){ Num = 2, Color = "gray", Model = "2022 Chevrolet Malibu", Manufacture = "Chevrolet" },
            new Car(){ Num = 3, Color = "black", Model = "2022 Hyundai Accent", Manufacture = "Hyundai" },
            new Car(){ Num = 4, Color = "gray", Model = "2022 Kia K5", Manufacture = "Kia" },
            new Car(){ Num = 5, Color = "blue", Model = "2022 Mercedes-Benz EQS", Manufacture = "Mercedes" },
            new Car(){ Num = 6, Color = "gray", Model = "2022 Nissan Versa", Manufacture = "Nissan" }
        };
    }
}