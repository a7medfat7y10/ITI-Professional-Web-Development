namespace Task_1.Models
{
    public class CarList
    {
        public static List<Car> Cars { get; set; } = new List<Car>()
        {
            new Car(){ Id = 1, Color = "red", Model = "2022 BMW 7 Series", Manufacture = "BMW" },
            new Car(){ Id = 2, Color = "gray", Model = "2022 Chevrolet Malibu", Manufacture = "Chevrolet" },
            new Car(){ Id = 3, Color = "black", Model = "2022 Hyundai Accent", Manufacture = "Hyundai" },
            new Car(){ Id = 4, Color = "gray", Model = "2022 Kia K5", Manufacture = "Kia" },
            new Car(){ Id = 5, Color = "blue", Model = "2022 Mercedes-Benz EQS", Manufacture = "Mercedes" },
            new Car(){ Id = 6, Color = "gray", Model = "2022 Nissan Versa", Manufacture = "Nissan" }
        };
    }
}
