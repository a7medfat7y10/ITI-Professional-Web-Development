using Task_1.Validation;

namespace Task_1.Models
{
    public class Car
    {
            public int Id { get; set; }
            public string Color { get; set; }
            public string Model { get; set; }
            public string Manufacture { get; set; }
            public string Type { get; set; }    

            [DateInPast]
            public DateTime ProdDate { get; set; }
    }
}
